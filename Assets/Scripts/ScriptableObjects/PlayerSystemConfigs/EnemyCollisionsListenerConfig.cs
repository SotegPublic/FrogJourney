using UnityEngine;

namespace Platformer.Player
{
    [CreateAssetMenu(fileName = nameof(EnemyCollisionsListenerConfig), menuName = "Configs/" + nameof(EnemyCollisionsListenerConfig), order = 5)]
    public class EnemyCollisionsListenerConfig : ScriptableObject
    {
        [SerializeField] private float _damageZoneAngle;
        [SerializeField] private LayerMask _enemyLayer;

        public LayerMask EnemyLayer => _enemyLayer;
        public float DamageZoneAngle => _damageZoneAngle;
    }
}