using Platformer.Core;
using UnityEngine;

namespace Platformer.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig), order = 2)]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Move setting")]
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _playerSpeedDecayModifier;
        [Header("Jump settings")]
        [SerializeField] private float _playerJumpForce;
        [SerializeField] private float _playerSpeedOnJumpModifier;
        [SerializeField] private float _damageJumpForece;
        [SerializeField] private Vector2 _damageJumpDirection;
        [Header("Dash settings")]
        [SerializeField] private float _playerDashSpeed;
        [SerializeField] private int _playerDashFrameCount;
        [SerializeField] private int _playerDashCount;
        [Header("Health settings")]
        [SerializeField] private int _playerHealth;
        [Header("Core")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private float _groundDetectDelay;

        public float PlayerSpeed => _playerSpeed;
        public float PlayerSpeedDecayModifier => _playerSpeedDecayModifier;
        public float PlayerJumpForce => _playerJumpForce;
        public float DamageJumpForce => _damageJumpForece;
        public float PlayerSpeedOnJumpModifier => _playerSpeedOnJumpModifier;
        public float PlayerDashSpeed => _playerDashSpeed;
        public int PlayerDashFrameCount => _playerDashFrameCount;
        public int PlayerDashCount => _playerDashCount;
        public GameObject PlayerPrefab => _playerPrefab;
        public float GroundDetectDelay => _groundDetectDelay;
        public Vector2 DamageJumpDerection => _damageJumpDirection;
        public int PlayerHealth => _playerHealth;
    }
}