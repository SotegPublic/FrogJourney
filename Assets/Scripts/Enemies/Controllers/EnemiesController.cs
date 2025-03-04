using Platformer.Core;
using Platformer.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemiesController: IUpdateble
    {
        private AnimationsController _animationsController;
        private EnemiesPool _enemiesPool;
        private EnemyMoveController _enemyMoveController;
        private IPlayerTransformModel _playerTransformModel;
        private int _loadRange;

        private List<EnemySpawnPoint> _enemySpawnPoints;
        private Dictionary<string, EnemyView> _enemiesOnScene = new Dictionary<string, EnemyView>(10);

        public EnemiesController(AnimationsController animationsController, EnemyPoolConfig enemyPoolConfig,
            Transform objectPoolHolder, int loadRange, IPlayerTransformModel playerTransformModel, List<EnemyProtoModel> protoModels) 
        {
            _animationsController = animationsController;
            _enemiesPool = new EnemiesPool(enemyPoolConfig, objectPoolHolder);

            _enemyMoveController = new EnemyMoveController();

            _playerTransformModel = playerTransformModel;
            _loadRange = loadRange;

            _enemySpawnPoints = new List<EnemySpawnPoint>(protoModels.Count);

            for (int i = 0; i < protoModels.Count; i++)
            {
                protoModels[i].SetEnemyID();
                _enemySpawnPoints.Add(new EnemySpawnPoint(protoModels[i]));
            }
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < _enemySpawnPoints.Count; i++)
            {
                var distance = Math.Abs(_enemySpawnPoints[i].EnemyProtoModel.SpawnPosition.position.x - _playerTransformModel.PlayerTransform.position.x);

                if (distance <= _loadRange && !_enemySpawnPoints[i].IsOnScene && !_enemySpawnPoints[i].IsDefeated)
                {
                    LoadEnemy(_enemySpawnPoints[i].EnemyProtoModel);
                    _enemySpawnPoints[i].IsOnScene = true;
                }
                else if (_enemySpawnPoints[i].IsOnScene && (distance > _loadRange || _enemySpawnPoints[i].IsDefeated))
                {
                    UnloadEnemy(_enemySpawnPoints[i].EnemyProtoModel.EnemyID);
                    _enemySpawnPoints[i].IsOnScene = false;
                }
            }
            _enemyMoveController.Move(deltaTime);
        }

        public void EnemyGetDamage(string enemyID)
        {
            var enemy = _enemiesOnScene[enemyID];

            _animationsController.ChangeAnimation(enemy.EnemyModel.SpriteRenderer, AnimationsTypes.Death, enemy.EnemyModel.ActorType, false,
                OnAnimationEndCallBack: () => { MarkEnemyPointAsDefeated(enemyID);}
                );

            enemy.EnemyModel.Collider2D.enabled = false;
            enemy.EnemyModel.IsStopped = true;
        }

        public void MarkEnemyPointAsDefeated(string enemyID)
        {
            var enemyPoint = FindSpawnPoint(enemyID);

            if(enemyPoint != null)
            {
                enemyPoint.IsDefeated = true;
            }
        }

        private void LoadEnemy(EnemyProtoModel enemyProtoModel)
        {
            var newEnemy = _enemiesPool.GetEnemy(enemyProtoModel.ActorType);
            _enemiesOnScene.Add(enemyProtoModel.EnemyID, newEnemy);

            newEnemy.EnemyModel.FillEnemyModel(enemyProtoModel);
            newEnemy.EnemyModel.Transform.SetParent(null);


            if (enemyProtoModel.IsPatrolling)
            {
                newEnemy.EnemyModel.Transform.position = enemyProtoModel.PatrolPoints[0].position;
                _enemyMoveController.AddEnemy(newEnemy.EnemyModel);
                _animationsController.ChangeAnimation(newEnemy.EnemyModel.SpriteRenderer, AnimationsTypes.Move, newEnemy.EnemyModel.ActorType, true);
            }
            else
            {
                newEnemy.EnemyModel.Transform.position = enemyProtoModel.SpawnPosition.position;
            }
        }

        private void UnloadEnemy(string enemyID)
        {
            var enemy = _enemiesOnScene[enemyID];

            _enemyMoveController.RemoveEnemy(enemy.EnemyModel);
            _animationsController.StopAnimation(enemy.EnemyModel.SpriteRenderer);

            _enemiesPool.ReturnEnemy(enemy);
            _enemiesOnScene.Remove(enemyID);
            enemy.EnemyModel.ClearEnemyModel();
        }

        private EnemySpawnPoint FindSpawnPoint(string enemyID)
        {
            for (int i = 0; i < _enemySpawnPoints.Count; i++)
            {
                if (_enemySpawnPoints[i].EnemyProtoModel.EnemyID == enemyID)
                {
                    return _enemySpawnPoints[i];
                }
            }

            return null;
        }
    }
}
