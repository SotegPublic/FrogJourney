using System;
using UnityEngine;

namespace Platformer.Player
{
    public interface IСollisionableView
    {
        public Action<Collision2D> OnCollisionEnter { get; set; }
        public Action<Collision2D> OnCollisionExit { get; set; }
    }
}