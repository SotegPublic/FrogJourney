using Platformer.Core;

namespace Platformer.Player
{
    public sealed class FallState : PlayerState
    {
        public FallState() : base(false, false, false, true, false, false, AnimationsTypes.Fall, true)
        {
        }
    }
}
