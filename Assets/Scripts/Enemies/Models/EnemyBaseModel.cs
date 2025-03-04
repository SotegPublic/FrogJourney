using Platformer.Core;
using Platformer.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    [Serializable]
    public class EnemyBaseModel: AnimatedObjectModel, ITransformMovingEnemyModel
    {
        [SerializeField] protected Collider2D _collider2D;
        [SerializeField] protected Transform _transform;

        private List<Vector2> _patrolPoints = new List<Vector2>(4);
        private float _patrolSpeed;
        private string _enemyID;
        private bool _isDefeat;
        

        public Collider2D Collider2D => _collider2D;
        public Transform Transform => _transform;
        public List<Vector2> PatrolPoints => _patrolPoints;
        public float PatrolSpeed => _patrolSpeed;
        public string EnemyID => _enemyID;
        public bool IsDefeat => _isDefeat;

        public int CurrentPatrolPoint { get; set; }
        public int PatrolPointsListDirectionModifier { get; set; }
        public int ScaleModifier { get; set; }
        public float LerpProgress { get; set; }
        public Vector2 LastPatrolPosition { get; set; }
        public bool IsStopped { get; set; }

        public void FillEnemyModel(EnemyProtoModel enemyConfig)
        {
            for(int i = 0; i < enemyConfig.PatrolPoints.Count; i++)
            {
                _patrolPoints.Add(enemyConfig.PatrolPoints[i].position);
            }

            _patrolSpeed = enemyConfig.PatrolSpeed;
            _enemyID = enemyConfig.EnemyID;

            CurrentPatrolPoint = 1;
            PatrolPointsListDirectionModifier = 1;
            ScaleModifier = 0;
            LerpProgress= 0;

            if(enemyConfig.IsPatrolling)
            {
                LastPatrolPosition = enemyConfig.PatrolPoints[0].position;
            }
            else
            {
                LastPatrolPosition = enemyConfig.SpawnPosition.position;
            }
        }

        public void ClearEnemyModel()
        {
            _patrolPoints.Clear();
            _patrolSpeed = 0;
            _enemyID = "";

            CurrentPatrolPoint = 0;
            PatrolPointsListDirectionModifier = 0;
            ScaleModifier = 0;
            LerpProgress = 0;
            LastPatrolPosition = Vector2.zero;
        }
    }
}