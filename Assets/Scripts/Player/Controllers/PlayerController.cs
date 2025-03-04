using Platformer.Core;
using Platformer.Input;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerController : IFixedUpdateble, IUpdateble, ICollisionEnterListener, ICollisionExitListener
    {
        private PlayerFactory _factory;
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private Transform _startPosition;

        private PlayerMoveController _moveController;
        private PlayerSlideDetector _playerSlideDetector;
        private PlayerStatesController _playerStatesController;
        private PlayerGroundDetectorController _groundDetectorController;
        private PlayerStatesSwitcher _playerStatesSwitcher;
        private PlayerDamageHandler _damageHandler;

        public IPlayerTransformModel PlayerTransformModel => _playerModel;
        public PlayerView PlayerView => _playerView;

        public PlayerController(PlayerConfig playerConfig, InputSystemModel inputSystemModel, Transform startTransorm, AnimationsController animationsController,
            PlayerDamageHandlerConfig playerDamageHandlerConfig)
        {
            _startPosition = startTransorm;
            _factory = new PlayerFactory(playerConfig);

            InitPlayer();

            _moveController = new PlayerMoveController(_playerModel, inputSystemModel);
            _groundDetectorController = new PlayerGroundDetectorController(_playerModel);
            _playerSlideDetector = new PlayerSlideDetector(_playerModel);

            _playerStatesController = new PlayerStatesController(_playerModel, animationsController);
            _playerStatesSwitcher = new PlayerStatesSwitcher(_playerModel, _playerStatesController, inputSystemModel);
            _damageHandler = new PlayerDamageHandler(playerDamageHandlerConfig, _playerStatesSwitcher, _moveController, _playerModel);
        }

        private void InitPlayer()
        {
            _playerView = _factory.CreatePlayer(_startPosition.position);
            _playerModel = _playerView.ObjectModel;
        }

        public void Update(float deltaTime)
        {
            _damageHandler.Update(deltaTime);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _groundDetectorController.FixedUpdate(fixedDeltaTime);
            _moveController.FixedUpdate(fixedDeltaTime);
            _playerStatesSwitcher.FixedUpdate(fixedDeltaTime);
        }

        public void PlayerGetDamage(int direction)
        {
            _damageHandler.GetDamage(direction);
        }

        public void OnPlayerCollisionEnter(Collision2D collision)
        {
            _playerSlideDetector.OnPlayerCollisionEnter(collision);
        }

        public void OnPlayerCollisionExit(Collision2D collision)
        {
            _playerSlideDetector.OnPlayerCollisionExit(collision);
        }
    }
}
