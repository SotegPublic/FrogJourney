using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    [CreateAssetMenu(fileName = nameof(EnemyPoolConfig), menuName = "Configs/" + nameof(EnemyPoolConfig), order = 3)]
    public class EnemyPoolConfig : ScriptableObject
    {
        [SerializeField] private int _countObjectCopies;
        [SerializeField] private List<EnemyPrototype> _enemiesPrototypes;

        public int CountObjectCopies => _countObjectCopies;
        public List<EnemyPrototype> EnemiesPrototypes => _enemiesPrototypes;
    }
}