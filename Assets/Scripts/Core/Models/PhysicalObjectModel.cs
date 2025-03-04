using System;
using UnityEngine;

namespace Platformer.Core
{
    [Serializable]
    public class PhysicalObjectModel: AnimatedObjectModel, IObjectModel
    {
        [SerializeField] protected Collider2D _collider2D;
        [SerializeField] protected Rigidbody2D _rigidbody2D;

        public Collider2D Collider2D => _collider2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Vector2 Velocity => _rigidbody2D.velocity;
    }
}
