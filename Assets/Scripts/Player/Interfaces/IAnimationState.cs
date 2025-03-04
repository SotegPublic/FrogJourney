using Platformer.Core;
using System;

namespace Platformer.Player
{
    public interface IAnimationState
    {
        public void OnRunState(AnimationsController animationsController, IAnimatedObjectModel playerModel, Action callBack = null);
        public void OnExitState(AnimationsController animationsController, IAnimatedObjectModel playerModel);
    }
}
