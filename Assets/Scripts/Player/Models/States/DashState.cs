using Platformer.Core;

namespace Platformer.Player
{
    public sealed class DashState : PlayerState
    {
        public DashState() : base(false, false, false, false, true, false, AnimationsTypes.AirDash, false)
        {
        }
    }
}
