using UnityEngine;

namespace Platformer.Core
{
    public interface ICollisionEnterListener: ICollisionListener
    {
        public void OnPlayerCollisionEnter(Collision2D collision);
    }
}