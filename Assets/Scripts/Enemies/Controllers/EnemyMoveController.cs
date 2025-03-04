using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemyMoveController
    {
        private List<ITransformMovingEnemyModel> _movingEmiesModels = new List<ITransformMovingEnemyModel>();

        public void Move(float deltaTime)
        {
            for (int i = 0; i < _movingEmiesModels.Count; i++)
            {
                if (_movingEmiesModels[i].IsStopped) { continue; }

                var currentPatrollPointIndex = _movingEmiesModels[i].CurrentPatrolPoint;
                var targetPatrollPoint = _movingEmiesModels[i].PatrolPoints[currentPatrollPointIndex];

                _movingEmiesModels[i].LerpProgress += deltaTime / (1 / _movingEmiesModels[i].PatrolSpeed);

                var direction = Vector2.Lerp(_movingEmiesModels[i].LastPatrolPosition, targetPatrollPoint, _movingEmiesModels[i].LerpProgress);

                _movingEmiesModels[i].Transform.position = direction;

                if (_movingEmiesModels[i].LerpProgress >= 1)
                {
                    _movingEmiesModels[i].LerpProgress = 0;

                    if(_movingEmiesModels[i].CurrentPatrolPoint + _movingEmiesModels[i].PatrolPointsListDirectionModifier > _movingEmiesModels[i].PatrolPoints.Count - 1 ||
                       _movingEmiesModels[i].CurrentPatrolPoint + _movingEmiesModels[i].PatrolPointsListDirectionModifier < 0)
                    {
                        _movingEmiesModels[i].PatrolPointsListDirectionModifier *= -1;
                    }

                    _movingEmiesModels[i].LastPatrolPosition = targetPatrollPoint;
                    _movingEmiesModels[i].CurrentPatrolPoint += _movingEmiesModels[i].PatrolPointsListDirectionModifier;
                }

                Scale(_movingEmiesModels[i]);
            }
        }

        private void Scale(ITransformMovingEnemyModel transformMovingObjectModel)
        {
            var currentPatrollPointIndex = transformMovingObjectModel.CurrentPatrolPoint;
            var nextPointX = transformMovingObjectModel.PatrolPoints[currentPatrollPointIndex].x;
            var currentX = transformMovingObjectModel.Transform.position.x;

            var scaleMod = (nextPointX - currentX) > 0 ? 1 : -1;

            if(transformMovingObjectModel.ScaleModifier != scaleMod)
            {
                transformMovingObjectModel.ScaleModifier = scaleMod;
                transformMovingObjectModel.Transform.localScale = new Vector3(scaleMod, 1, 1);
            }
        }

        public void AddEnemy(ITransformMovingEnemyModel model)
        {
            _movingEmiesModels.Add(model);
        }

        public void RemoveEnemy(ITransformMovingEnemyModel model)
        {
            _movingEmiesModels.Remove(model);
        }
    }
}
