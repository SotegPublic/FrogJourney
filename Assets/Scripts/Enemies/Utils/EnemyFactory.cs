using Platformer.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemyFactory
    {
        private Dictionary<ActorsTypes, EnemyPrototype> _enemyPrototypesByTypes;

        public EnemyFactory(List<EnemyPrototype> enemiesPrototypes)
        {
            CreateDictionary(enemiesPrototypes);
        }

        private void CreateDictionary(List<EnemyPrototype> enemiesPrototypes)
        {
            _enemyPrototypesByTypes = new Dictionary<ActorsTypes, EnemyPrototype>(enemiesPrototypes.Count);

            for(int i = 0; i < enemiesPrototypes.Count; i++)
            {
                if (!_enemyPrototypesByTypes.ContainsKey(enemiesPrototypes[i].ActorType))
                {
                    _enemyPrototypesByTypes.Add(enemiesPrototypes[i].ActorType, enemiesPrototypes[i]);
                }
            }
        }

        public EnemyView CreateEnemy(ActorsTypes actorType, Transform poolHolder)
        {
            var prototype = _enemyPrototypesByTypes[actorType].Prototype;
            var enemyObject = Object.Instantiate(prototype, poolHolder);
            var view = enemyObject.GetComponent<EnemyView>();

            return view;
        }
    }
}
