using Platformer.Core;
using System;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerDamageHandler: IUpdateble
    {
        private PlayerStatesSwitcher _playerStatesSwitcher;
        private PlayerMoveController _moveController;
        private IDamagebleModel _playerModel;

        private bool _isInvulnerable;
        private float _currentInvulnerableduration;

        private float _maxInvulnerabilityduration;
        private Color _damageColor;
        private Color _baseColor;

        public PlayerDamageHandler(PlayerDamageHandlerConfig playerDamageHandlerConfig, PlayerStatesSwitcher playerStatesSwitcher,
            PlayerMoveController moveController, IDamagebleModel playerModel)
        {
            _playerStatesSwitcher = playerStatesSwitcher;
            _moveController = moveController;
            _playerModel = playerModel;

            _damageColor = playerDamageHandlerConfig.DamagedColor;
            _baseColor = playerDamageHandlerConfig.BaseColor;
            _maxInvulnerabilityduration = playerDamageHandlerConfig.InvulnerableDuration;
        }

        public void Update(float deltaTime)
        {
            if(_isInvulnerable )
            {
                _currentInvulnerableduration += deltaTime;

                if((Math.Round(_currentInvulnerableduration, 1) * 10) % 2 == 0) // blink every 0,2 sec
                {
                    _playerModel.SpriteRenderer.color = _damageColor;
                }
                else
                {
                    _playerModel.SpriteRenderer.color = _baseColor;
                }

                if(_maxInvulnerabilityduration < _currentInvulnerableduration)
                {
                    _isInvulnerable = false;
                    _currentInvulnerableduration = 0;
                    _playerModel.SpriteRenderer.color = _baseColor;
                    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(LayersNames.PLAYER), LayerMask.NameToLayer(LayersNames.ENEMY), false);
                }
            }
        }

        public void GetDamage(int direction)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(LayersNames.PLAYER), LayerMask.NameToLayer(LayersNames.ENEMY), true);
            _playerStatesSwitcher.SetDamageState(OnHitAnimationEnd);
            _moveController.DamageJump(direction);
            _isInvulnerable = true;

            _playerModel.Health.RemoveHealth(1);

            if (_playerModel.Health.GetHealth() == 0)
            {
                Debug.Log("GameOver");
            }
        }

        public void OnHitAnimationEnd()
        {
            _playerStatesSwitcher.SetIdleState();
        }
    }
}
