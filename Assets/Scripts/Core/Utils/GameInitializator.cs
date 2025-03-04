using Platformer.Enemy;
using Platformer.Input;
using Platformer.Player;

namespace Platformer.Core
{
    public class GameInitializator
    {
        public void InitGame(GameConfigs configs, GameController gameController)
        {
            var inputController = new InputSystemController();
            var animationsController = new AnimationsController(configs.SpriteAnimatorConfigs);
            var playerController = new PlayerController(configs.PlayerConfig, inputController.InputModel, configs.StartPosition, animationsController, configs.PlayerDamageHandlerConfig);

            var enemiesController = new EnemiesController(animationsController, configs.EnemyPoolConfig, configs.PoolObjectsHolder, configs.EnemiesLoadDistance,
                playerController.PlayerTransformModel, configs.EnemyProtoModels);

            var playerCollisionObserver = new PlayerCollisionObserver(playerController.PlayerView);
            var enemyCollisionsListener = new EnemyCollisionsListener(playerController, enemiesController, configs.EnemyCollisionsListenerConfig);

            gameController.AddController(animationsController);
            gameController.AddController(inputController);
            gameController.AddController(playerController);
            gameController.AddController(enemiesController);

            playerCollisionObserver.Subscribe(enemyCollisionsListener);
            playerCollisionObserver.Subscribe(playerController);

            gameController.AddDisposable(playerCollisionObserver);
        }
    }
}