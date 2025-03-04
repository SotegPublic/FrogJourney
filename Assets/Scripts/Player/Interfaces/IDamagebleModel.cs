using Platformer.Core;
using UnityEngine;

namespace Platformer.Player
{
    public interface IDamagebleModel
    {
        public HealthProperty Health { get; }
        public SpriteRenderer SpriteRenderer { get; }
    }
}
