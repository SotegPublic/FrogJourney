using Platformer.Core;
using System;

namespace Platformer.Player
{
    public class PlayerState : IPlayerState, IAnimationState
    {
        protected AnimationsTypes _animationType;
        protected bool _isStateAnimationLooped;

        public bool IsIdle { get; private set; }

        public bool IsRun { get; private set; }

        public bool IsJump { get; private set; }

        public bool IsFall { get; private set; }

        public bool IsDash { get; private set; }
        public bool IsHit { get; private set; }


        protected PlayerState(bool isStay, bool isRun, bool isJump, bool isFall, bool isDash, bool isHit, AnimationsTypes animType, bool isAnimationLooped)
        {
            IsIdle = isStay;
            IsRun = isRun;
            IsJump = isJump;
            IsFall = isFall;
            IsDash = isDash;
            IsHit = isHit;

            _animationType = animType;
            _isStateAnimationLooped = isAnimationLooped; 
        }

        public void OnRunState(AnimationsController animationsController, IAnimatedObjectModel playerModel, Action callBack = null)
        {
            animationsController.ChangeAnimation(playerModel.SpriteRenderer, _animationType, playerModel.ActorType, _isStateAnimationLooped, callBack);
        }

        public void OnExitState(AnimationsController animationsController, IAnimatedObjectModel playerModel)
        {
            animationsController.StopAnimation(playerModel.SpriteRenderer);
        }
    }
}
