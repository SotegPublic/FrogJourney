using Platformer.Core;

namespace Platformer.Player
{
    public sealed class JumpState : PlayerState
    {
        public JumpState() : base(false, false, true, false, false, false, AnimationsTypes.Jump, true)
        {
        }
    }
}
