namespace Platformer.Player
{
    public interface IPlayerState
    {
        public bool IsIdle { get; }
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsFall { get; }
        public bool IsDash { get; }
        public bool IsHit { get; }
    }
}
