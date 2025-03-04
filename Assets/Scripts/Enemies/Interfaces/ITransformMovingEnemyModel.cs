using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public interface ITransformMovingEnemyModel
    {
        public Transform Transform { get; }
        public List<Vector2> PatrolPoints { get; }
        public int CurrentPatrolPoint { get; set; }
        public int PatrolPointsListDirectionModifier { get; set; }
        public float PatrolSpeed { get; }
        public int ScaleModifier { get; set; }
        public float LerpProgress { get; set; }
        public Vector2 LastPatrolPosition { get; set; }
        public bool IsStopped { get; set; }
    }
}