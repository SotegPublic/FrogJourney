using UnityEngine;

namespace Platformer.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerDamageHandlerConfig), menuName = "Configs/" + nameof(PlayerDamageHandlerConfig), order = 4)]
    public class PlayerDamageHandlerConfig: ScriptableObject
    {
        [SerializeField] private Color _damagedColor;
        [SerializeField] private Color _baseColor;
        [SerializeField] private float _invulnerableDuration;

        public Color DamagedColor => _damagedColor;
        public Color BaseColor => _baseColor;
        public float InvulnerableDuration => _invulnerableDuration;
    }
}
