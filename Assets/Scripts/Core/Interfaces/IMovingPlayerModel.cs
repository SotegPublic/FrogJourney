using Platformer.Player;
using UnityEngine;

namespace Platformer.Player
{
    public interface IMovingPlayerModel
    {
        public Transform PlayerTransform { get; }
        public IPlayerState CurrentPlayerState { get; }

        //Move
        public Rigidbody2D Rigidbody2D { get; }
        public float PlayerSpeed { get; }
        public float PlayerSpeedDecayModifier { get; }
        public float PlayerJumpForce { get; }
        public float DamageJumpForce { get; }
        public Vector2 DamageJumpDirection { get; }
        public float PlayerSpeedOnJumpModifier { get; }
        public bool IsOnGround { get; }
        public bool IsSlideOnWall { get; }

        //Dash
        public float PlayerDashSpeed { get; }
        public float PlayerDashFrameCount { get; }
        public float PlayerDashCount { get; }
        public int CurrentPlayerDashesCount { get; set; }
        public bool IsDashing { get; set; }

    }
}