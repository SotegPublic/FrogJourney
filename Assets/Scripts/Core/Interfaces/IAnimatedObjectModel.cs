using UnityEngine;

namespace Platformer.Core
{
    public interface IAnimatedObjectModel
    {
        public ActorsTypes ActorType { get; }
        public SpriteRenderer SpriteRenderer { get; }
    }
}
