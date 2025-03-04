using Platformer.Core;
using Platformer.Input;
using System;
using UnityEngine;

namespace Platformer.Player
{

    public class PlayerMoveController: IFixedUpdateble
    {
        private IMovingPlayerModel _playerModel;
        private InputSystemModel _inputSystemModel;

        private Vector2 _direction;
        private int _currentDashFrameCount = 0;

        public PlayerMoveController(IMovingPlayerModel playerModel, InputSystemModel inputSystemModel) 
        {
            _playerModel = playerModel;
            _inputSystemModel = inputSystemModel;

            _inputSystemModel.OnJumpButtonClick += Jump;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if(_playerModel.CurrentPlayerState.IsHit) { return; }

            Scale();

            if (!_playerModel.CurrentPlayerState.IsDash)
            {
                if (_inputSystemModel.MoveDirection.x != 0 && !_playerModel.IsSlideOnWall)
                {
                    Move(_inputSystemModel.MoveDirection, !_playerModel.IsOnGround);
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                Dash();
            }

            if(_playerModel.IsOnGround)
            {
                ResetDashesCountOnGround();
            }
        }

        public void DamageJump(int direction)
        {
            if (_playerModel.CurrentPlayerState.IsHit)
            {
                var finalDamageDirection = new Vector2(_playerModel.DamageJumpDirection.x * direction, _playerModel.DamageJumpDirection.y);
                _playerModel.Rigidbody2D.velocity = finalDamageDirection * _playerModel.DamageJumpForce;
            }
        }

        private void Scale()
        {
            var scaleMod = _inputSystemModel.MoveDirection.x > 0 ? 1 : (_inputSystemModel.MoveDirection.x < 0 ? -1 : _playerModel.PlayerTransform.localScale.x);

            _playerModel.PlayerTransform.localScale = new Vector3(scaleMod, 1, 1);
        }

        private void ResetDashesCountOnGround()
        {
            if(_playerModel.CurrentPlayerDashesCount > 0)
            {
                _playerModel.CurrentPlayerDashesCount = 0;
            }
        }

        private void Move(Vector2 moveVector, bool isJump)
        {
            _direction = moveVector * _playerModel.PlayerSpeed;

            if(isJump)
            {
                _direction.x = _direction.x * _playerModel.PlayerSpeedOnJumpModifier;
            }

            _direction.y = _playerModel.Rigidbody2D.velocity.y;
            _playerModel.Rigidbody2D.velocity = _direction;
        }

        private void Jump()
        {
            if (_playerModel.IsOnGround && !_playerModel.CurrentPlayerState.IsHit)
            {
                _playerModel.Rigidbody2D.velocity = Vector2.up * _playerModel.PlayerJumpForce;
            }
        }

        private void Dash()
        {
            if (!_playerModel.IsDashing)
            {
                _playerModel.IsDashing = true;
                _playerModel.CurrentPlayerDashesCount++;
            }

            var currentPosition = _playerModel.PlayerTransform.position;
            currentPosition.x = currentPosition.x + (_playerModel.PlayerTransform.localScale.x * _playerModel.PlayerDashSpeed);

            _playerModel.Rigidbody2D.MovePosition(currentPosition);
            _currentDashFrameCount++;
            if(_currentDashFrameCount == _playerModel.PlayerDashFrameCount)
            {
                var velocity = _playerModel.Rigidbody2D.velocity;
                velocity.y = 0;
                _playerModel.Rigidbody2D.velocity = velocity;
                _currentDashFrameCount = 0;
                _playerModel.IsDashing = false;
            }
        }

        private void Stop()
        {
            _direction = new Vector2(_playerModel.Rigidbody2D.velocity.x * _playerModel.PlayerSpeedDecayModifier, _direction.y);
            _direction.y = _playerModel.Rigidbody2D.velocity.y;

            _playerModel.Rigidbody2D.velocity = _direction;
        }
    }
}