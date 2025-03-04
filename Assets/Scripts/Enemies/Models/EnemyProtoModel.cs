using Platformer.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    [Serializable]
    public class EnemyProtoModel
    {
        [SerializeField] private ActorsTypes _actorType;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private bool _isPatrolling;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField][Range(0.1f, 4f)] private float _patrolSpeed = 1;

        private string _enemyID;


        public ActorsTypes ActorType => _actorType;
        public Transform SpawnPosition => _spawnPosition;
        public bool IsPatrolling => _isPatrolling;
        public List<Transform> PatrolPoints => _patrolPoints;
        public float PatrolSpeed => _patrolSpeed;
        public string EnemyID => _enemyID;

        public void SetEnemyID()
        {
            _enemyID = (int)_actorType + ((int)_spawnPosition.position.x).ToString() + ((int)_spawnPosition.position.y).ToString() + ((int)_spawnPosition.position.z).ToString();
        }
    }
}