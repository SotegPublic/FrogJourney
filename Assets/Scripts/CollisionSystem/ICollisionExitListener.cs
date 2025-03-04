using UnityEngine;

namespace Platformer.Core
{
    public interface ICollisionExitListener: ICollisionListener
    {
        public void OnPlayerCollisionExit(Collision2D collision);
    }
}