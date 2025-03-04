using Platformer.Core;
using Platformer.Input;
using System;

namespace Platformer.Player
{
    public class PlayerStatesSwitcher: IFixedUpdateble
    {
        private IMovingPlayerModel _playerModel;
        private PlayerStatesController _playerStatesController;
        private InputSystemModel _inputSystemModel;

        public PlayerStatesSwitcher(IMovingPlayerModel playerModel, PlayerStatesController playerStatesController, InputSystemModel inputSystemModel)
        {
            _playerModel = playerModel;
            _playerStatesController = playerStatesController;
            _inputSystemModel = inputSystemModel;

            _inputSystemModel.OnJumpButtonClick += StartAirDashState;
        }

        public void FixedUpdate(float deltaTime)
        {
            if(_playerModel.CurrentPlayerState.IsHit) { return; }
            
            if (!_playerModel.CurrentPlayerState.IsDash)
            {
                if (_playerModel.IsOnGround)
                {
                    if (_inputSystemModel.MoveDirection.x != 0)
                    {
                        if (_playerModel.CurrentPlayerState.IsRun) return;
                        _playerStatesController.ChangeState(AnimationsTypes.Move);
                    }
                    else
                    {
                        if (_playerModel.CurrentPlayerState.IsIdle) return;
                        _playerStatesController.ChangeState(AnimationsTypes.Idle);
                    }
                }
                else
                {
                    if (_playerModel.Rigidbody2D.velocity.y < 0)
                    {
                        if (_playerModel.CurrentPlayerState.IsFall) return;
                        _playerStatesController.ChangeState(AnimationsTypes.Fall);
                    }
                    else if(_playerModel.Rigidbody2D.velocity.y > 0)
                    {
                        if (_playerModel.CurrentPlayerState.IsJump) return;
                        _playerStatesController.ChangeState(AnimationsTypes.Jump);
                    }
                }
            }
            else
            {
                if(!_playerModel.IsDashing)
                {
                    _playerStatesController.ChangeState(AnimationsTypes.Jump);
                }
            }
        }

        public void StartAirDashState()
        {
            if (!_playerModel.IsOnGround && _playerModel.CurrentPlayerDashesCount < _playerModel.PlayerDashCount)
            {
                _playerStatesController.ChangeState(AnimationsTypes.AirDash);
            }
        }

        public void SetDamageState(Action callback)
        {
            if(!_playerModel.CurrentPlayerState.IsHit)
            {
                _playerStatesController.ChangeState(AnimationsTypes.Hit, callback);
            }
        }

        public void SetIdleState()
        {
            if (!_playerModel.CurrentPlayerState.IsIdle)
            {
                _playerStatesController.ChangeState(AnimationsTypes.Idle);
            }
        }
    }
}
