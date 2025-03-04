using System;
using UnityEngine;

namespace Platformer.Core
{
    [Serializable]
    public class AnimatedObjectModel: IAnimatedObjectModel
    {
        [SerializeField] protected ActorsTypes _actorType;
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        public ActorsTypes ActorType => _actorType;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}
