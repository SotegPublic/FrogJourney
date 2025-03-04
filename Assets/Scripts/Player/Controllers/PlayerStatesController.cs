using Platformer.Core;
using System;

namespace Platformer.Player
{
    public class PlayerStatesController
    {
        private PlayerModel _playerModel;
        private AnimationsController _animationsController;

        private IAnimationState _currentState;
        private IdleState _idleState;
        private RunState _runState;
        private JumpState _jumpState;
        private FallState _fallState;
        private DashState _dashState;
        private HitState _hitState;

        public PlayerStatesController(PlayerModel playerModel, AnimationsController animationsController)
        {
            _playerModel = playerModel;
            _animationsController = animationsController;

            Init();
        }

        private void Init()
        {
            _idleState = new IdleState();
            _runState = new RunState();
            _jumpState = new JumpState();
            _fallState = new FallState();
            _dashState = new DashState();
            _hitState = new HitState();


            ChangeState(AnimationsTypes.Idle);
        }

        public void ChangeState(AnimationsTypes animType, Action callback = null)
        {
            ExitFromCurrentState();

            switch (animType)
            {
                case AnimationsTypes.Idle:
                    SetSelectedAnimationState(_idleState);
                    _playerModel.SetPlayerState(_idleState);
                    break;
                case AnimationsTypes.Move:
                    SetSelectedAnimationState(_runState);
                    _playerModel.SetPlayerState(_runState);
                    break;
                case AnimationsTypes.Jump:
                    SetSelectedAnimationState(_jumpState);
                    _playerModel.SetPlayerState(_jumpState);
                    break;
                case AnimationsTypes.Fall:
                    SetSelectedAnimationState(_fallState);
                    _playerModel.SetPlayerState(_fallState);
                    break;
                case AnimationsTypes.AirDash:
                    SetSelectedAnimationState(_dashState);
                    _playerModel.SetPlayerState(_dashState);
                    break;
                case AnimationsTypes.Hit:
                    SetSelectedAnimationState(_hitState, callback);
                    _playerModel.SetPlayerState(_hitState);
                    break;
                case AnimationsTypes.None:
                default:
                    throw new System.Exception("Error on animations states change");
            }
        }

        public void SetSelectedAnimationState(IAnimationState state, Action callback = null)
        {
            state.OnRunState(_animationsController, _playerModel, callback);
            _currentState = state;
        }

        private void ExitFromCurrentState()
        {
            if (_currentState != null)
            {
                _currentState.OnExitState(_animationsController, _playerModel);
            }
        }
    }
}
