using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    public sealed class ObjectAnimationController: IDisposable, IUpdateble
    {
        public AnimationsTypes Track;
        public List<Sprite> Sprites;
        public bool Loop;
        public float Speed = 10;
        public float Counter = 0;
        public bool Sleep;
        public Action OnAnimationEndCallBack;

        public void Update(float deltaTime)
        {
            if (Sleep) return;

            Counter += deltaTime * Speed;

            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }

                OnAnimationEndCallBack?.Invoke();
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count;
                Sleep = true;

                OnAnimationEndCallBack?.Invoke();
            }
        }

        public void Dispose()
        {
            Sprites = null;
            OnAnimationEndCallBack = null;
        }
    }
}