
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerFactory
    {
        public PlayerConfig _playerConfig;

        public PlayerFactory(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
        }

        public PlayerView CreatePlayer(Vector3 playerPosition)
        {
            var playerObject = Object.Instantiate(_playerConfig.PlayerPrefab, playerPosition, Quaternion.identity);
            var playerView = playerObject.GetComponent<PlayerView>();

            playerView.ObjectModel.SetModelPatameters(_playerConfig);

            return playerView;
        }
    }
}
