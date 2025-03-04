using Platformer.Core;

namespace Platformer.Player
{
    public sealed class HitState : PlayerState
    {
        public HitState() : base(false, false, false, false, false, true, AnimationsTypes.Hit, false)
        {
        }
    }
}
