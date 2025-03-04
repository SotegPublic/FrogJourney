using UnityEngine;

namespace Platformer.Core
{
    public interface IPlayerCollisionEnterListener: IPlayerCollisionListener
    {
        public void OnPlayerCollisionEnter(Collision2D collision);
    }
}