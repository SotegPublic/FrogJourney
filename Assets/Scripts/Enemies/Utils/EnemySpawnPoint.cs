namespace Platformer.Enemy
{
    public class EnemySpawnPoint
    {
        private EnemyProtoModel _enemyProtoModel;

        public bool IsOnScene { get; set; }
        public bool IsDefeated { get; set; }

        public EnemyProtoModel EnemyProtoModel => _enemyProtoModel;

        public EnemySpawnPoint(EnemyProtoModel enemyConfig)
        {
            _enemyProtoModel = enemyConfig;
        }
    }
}
