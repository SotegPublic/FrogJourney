using Platformer.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemiesPool
    {
        private Transform _objectHolder;
        private EnemyFactory _enemyFactory;
        private int _baseCountCopies;

        private Dictionary<ActorsTypes, List<EnemyView>> _enemyViewsByTypes = new Dictionary<ActorsTypes, List<EnemyView>>();

        public EnemiesPool(EnemyPoolConfig config, Transform objectHolder)
        {
            _objectHolder = objectHolder;
            _baseCountCopies = config.CountObjectCopies;

            _enemyFactory = new EnemyFactory(config.EnemiesPrototypes);

            CreateDictionary(config.EnemiesPrototypes);
        }

        private void CreateDictionary(List<EnemyPrototype> enemiesPrototypes)
        {
            for(int i = 0; i < enemiesPrototypes.Count; i++)
            {
                if (!_enemyViewsByTypes.ContainsKey(enemiesPrototypes[i].ActorType))
                {
                    _enemyViewsByTypes.Add(enemiesPrototypes[i].ActorType, new List<EnemyView>(_baseCountCopies));
                }

                FillList(_enemyViewsByTypes[enemiesPrototypes[i].ActorType], enemiesPrototypes[i].ActorType);

            }
        }

        private void FillList(List<EnemyView> enemiesList, ActorsTypes actorType)
        {
            var copiesCount = 0;

            do
            {
                var newEnemy = _enemyFactory.CreateEnemy(actorType, _objectHolder);
                enemiesList.Add(newEnemy);
                copiesCount++;
            } while (copiesCount < _baseCountCopies);
        }

        public EnemyView GetEnemy(ActorsTypes actorType)
        {
            if (_enemyViewsByTypes[actorType].Count == 0)
            {
                var newEnemy = _enemyFactory.CreateEnemy(actorType, _objectHolder);
                return newEnemy;
            }
            else
            {
                var enemy = _enemyViewsByTypes[actorType][_enemyViewsByTypes[actorType].Count - 1];
                _enemyViewsByTypes[actorType].Remove(enemy);

                return enemy;
            }
        }

        public void ReturnEnemy(EnemyView enemyView)
        {
            _enemyViewsByTypes[enemyView.EnemyModel.ActorType].Add(enemyView);
            enemyView.EnemyModel.Transform.SetParent(_objectHolder);
            enemyView.EnemyModel.Transform.localPosition = Vector2.zero;
            enemyView.EnemyModel.Collider2D.enabled = true;
        }
    }
}
