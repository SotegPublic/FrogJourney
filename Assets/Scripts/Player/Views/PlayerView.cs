using Platformer.Core;
using Platformer.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerView : ObjectView<PlayerModel>, IÑollisionableView
    {
        public Action<Collision2D> OnCollisionEnter { get; set; }
        public Action<Collision2D> OnCollisionExit { get; set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter?.Invoke(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            OnCollisionExit?.Invoke(collision);
        }
    }
}