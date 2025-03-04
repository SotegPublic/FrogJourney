using Platformer.Core;
using Platformer.Enemy;
using System;
using UnityEngine;

namespace Platformer.Player
{
    public class EnemyCollisionsListener : IPlayerCollisionEnterListener
    {
        private PlayerController _playerController;
        private EnemiesController _enemiesController;
        private ContactPoint2D[] _contacts = new ContactPoint2D[2];
        private float _damageZoneAngle;
        private LayerMask _enemyLayer;

        public EnemyCollisionsListener(PlayerController playerController, EnemiesController enemiesController, EnemyCollisionsListenerConfig config)
        {
            _playerController = playerController;
            _enemiesController = enemiesController;
            _damageZoneAngle = config.DamageZoneAngle;
            _enemyLayer = config.EnemyLayer;
        }

        public void OnPlayerCollisionEnter(Collision2D collision)
        {
            if((1<<collision.gameObject.layer) == _enemyLayer)
            {
                CheckCollision(collision);
            }
        }

        private void CheckCollision(Collision2D collision)
        {
            collision.GetContacts(_contacts);
            var radiansDamageAngle = _damageZoneAngle * (Math.PI / 180); // get radians
            var cosDamageAngle = Math.Cos(radiansDamageAngle);

            if (_contacts[0].normal.y < cosDamageAngle)
            {
                var direction = _contacts[0].normal.x >= 0 ? 1 : -1;

                _playerController.PlayerGetDamage(direction);
            }
            else
            {
                var enemyView = collision.gameObject.GetComponent<EnemyView>();
                _enemiesController.EnemyGetDamage(enemyView.EnemyModel.EnemyID);
            }
        }
    }
}