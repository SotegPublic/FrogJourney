using Platformer.Core;
using System;
using UnityEngine;

namespace Platformer.Enemy
{
    [Serializable]
    public class EnemyPrototype
    {
        [SerializeField] private ActorsTypes _actorType;
        [SerializeField] private GameObject _prototype;

        public ActorsTypes ActorType => _actorType;
        public GameObject Prototype => _prototype;
    }
}