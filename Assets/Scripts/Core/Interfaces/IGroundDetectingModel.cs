using UnityEngine;

namespace Platformer.Core
{
    public interface IGroundDetectingModel
    {
        public Transform GroundDetector { get; }
        public LayerMask GroundLayer { get; }
        public bool IsOnGround { get; }
        public float GroundDetectRadius { get; }
        public Vector2 Velocity { get; }
        public float GroundDetectDelay { get; }

        public void SetIsOnGround(bool isOnGround);
    }
}