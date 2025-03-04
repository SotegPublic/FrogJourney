using System.Collections.Generic;
using System;
using UnityEngine;

namespace Platformer.Core
{
    [Serializable]
    public sealed class SpriteSequence
    {
        public AnimationsTypes Track;
        public float AnimationSpeed;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}