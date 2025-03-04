using Platformer.Core;
using Platformer.Enemy;
using System;
using UnityEngine;

namespace Platformer.Player
{
    [Serializable]
    public class PlayerModel : PhysicalObjectModel, IMovingPlayerModel, IGroundDetectingModel, IPlayerTransformModel, ISlideDetectingModel, IDamagebleModel
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _groundDetector;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _groundDetectRadius;

        private HealthProperty _health;
        private float _playerSpeed;
        private float _playerSpeedDecayModifier;
        private float _playerJumpForce;
        private float _damageJumpForce;
        private Vector2 _damageJumpDirection;
        private float _playerSpeedOnJumpModifier;
        private float _playerDashSpeed;
        private float _playerDashFrameCount;
        private float _playerDashCount;
        private bool _isOnGround;
        private bool _isSlideOnWall;
        private float _groundDetectDelay;
        private IPlayerState _currentPlayerState;
        
        public float PlayerSpeed => _playerSpeed;
        public float PlayerSpeedDecayModifier => _playerSpeedDecayModifier;
        public float PlayerJumpForce => _playerJumpForce;
        public float DamageJumpForce => _damageJumpForce;
        public Vector2 DamageJumpDirection => _damageJumpDirection;
        public float PlayerSpeedOnJumpModifier => _playerSpeedOnJumpModifier;
        public float PlayerDashSpeed => _playerDashSpeed;
        public float PlayerDashFrameCount => _playerDashFrameCount;
        public float PlayerDashCount => _playerDashCount;
        public Transform PlayerTransform => _transform;
        public Transform GroundDetector => _groundDetector;
        public LayerMask GroundLayer => _groundLayerMask;
        public float GroundDetectRadius => _groundDetectRadius;
        public float GroundDetectDelay => _groundDetectDelay;
        public bool IsOnGround => _isOnGround;
        public bool IsSlideOnWall => _isSlideOnWall;
        public IPlayerState CurrentPlayerState => _currentPlayerState;
        public HealthProperty Health => _health;

        public int CurrentPlayerDashesCount { get; set; }
        public bool IsDashing { get; set; }

        public void SetModelPatameters (PlayerConfig config)
        {
            _playerSpeed = config.PlayerSpeed;
            _playerSpeedDecayModifier = config.PlayerSpeedDecayModifier;
            _playerJumpForce = config.PlayerJumpForce;
            _damageJumpForce = config.DamageJumpForce;
            _damageJumpDirection = config.DamageJumpDerection;
            _playerSpeedOnJumpModifier = config.PlayerSpeedOnJumpModifier;
            _playerDashSpeed = config.PlayerDashSpeed;
            _playerDashFrameCount = config.PlayerDashFrameCount;
            _playerDashCount = config.PlayerDashCount;
            _groundDetectDelay = config.GroundDetectDelay;

            _health = new HealthProperty();
            _health.AddHealth(config.PlayerHealth);

        }

        public void SetPlayerState(IPlayerState state)
        {
            _currentPlayerState = state;
        }

        void IGroundDetectingModel.SetIsOnGround(bool isOnGround)
        {
            _isOnGround = isOnGround;
        }

        void ISlideDetectingModel.SetIsSlideOnWall(bool isSlideOnWall)
        {
            _isSlideOnWall = isSlideOnWall;
        }
    }
}