using Platformer.Core;

namespace Platformer.Player
{
    public sealed class RunState : PlayerState
    {
        public RunState() : base(false, true, false, false, false, false, AnimationsTypes.Move, true)
        {
        }
    }
}
