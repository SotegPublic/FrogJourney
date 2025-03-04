using UnityEngine;

namespace Platformer.Core
{
    public interface IPlayerCollisionExitListener: IPlayerCollisionListener
    {
        public void OnPlayerCollisionExit(Collision2D collision);
    }
}