using Platformer.Core;

namespace Platformer.Player
{
    public sealed class IdleState : PlayerState
    {
        public IdleState() : base(true, false, false, false, false, false, AnimationsTypes.Idle, true)
        {
        }
    }
}
