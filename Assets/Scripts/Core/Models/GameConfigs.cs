using Platformer.Enemy;
using Platformer.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    [Serializable]
    public class GameConfigs
    {
        [Header("Core")]
        [SerializeField] private List<SpriteAnimatorConfig> _spriteAnimatorConfigs;
        [Header("Player System")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private PlayerDamageHandlerConfig _playerDamageHandlerConfig;
        [SerializeField] private EnemyCollisionsListenerConfig _enemyCollisionsListener;
        [Header("Enemies System")]
        [SerializeField] private List<EnemyProtoModel> _enemyProtoModels;
        [SerializeField] private EnemyPoolConfig _enemyPoolConfig;
        [SerializeField] private Transform _poolObjectsHolder;
        [SerializeField] private int _enemiesLoadDistance;

        public List<SpriteAnimatorConfig> SpriteAnimatorConfigs => _spriteAnimatorConfigs;
        public PlayerConfig PlayerConfig => _playerConfig;
        public Transform StartPosition => _startPosition;
        public List<EnemyProtoModel> EnemyProtoModels => _enemyProtoModels;
        public EnemyPoolConfig EnemyPoolConfig => _enemyPoolConfig;
        public Transform PoolObjectsHolder => _poolObjectsHolder;
        public int EnemiesLoadDistance => _enemiesLoadDistance;
        public PlayerDamageHandlerConfig PlayerDamageHandlerConfig => _playerDamageHandlerConfig;
        public EnemyCollisionsListenerConfig EnemyCollisionsListenerConfig => _enemyCollisionsListener;
    }
}