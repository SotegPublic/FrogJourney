using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy {
    //[RequireComponent(typeof(PolygonCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyBaseModel _model;

        public EnemyBaseModel EnemyModel => _model;
    }
}
