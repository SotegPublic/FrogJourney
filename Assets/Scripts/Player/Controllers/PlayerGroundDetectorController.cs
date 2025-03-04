using Platformer.Core;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerGroundDetectorController : IFixedUpdateble
    {
        private IGroundDetectingModel _playerModel;
        private float _checkDelayTime;
        
        public PlayerGroundDetectorController(IGroundDetectingModel model)
        {
            _playerModel = model;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if (_playerModel.Velocity.y != 0 || (_playerModel.Velocity.y == 0 && !_playerModel.IsOnGround))
            {
                if (_checkDelayTime > 0)
                {
                    _checkDelayTime -= fixedDeltaTime;
                }
                else
                {
                    _playerModel.SetIsOnGround(Physics2D.OverlapCircle(_playerModel.GroundDetector.transform.position, _playerModel.GroundDetectRadius, _playerModel.GroundLayer));
                    _checkDelayTime = _playerModel.GroundDetectDelay;
                }
            }
            else
            {
                if(!_playerModel.IsOnGround)
                {
                    _playerModel.SetIsOnGround(true);
                }
            }
        }
    }
}
