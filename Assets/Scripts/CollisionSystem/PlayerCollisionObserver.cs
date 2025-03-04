using Platformer.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    public class PlayerCollisionObserver: IDisposable
    {
        private IÑollisionableView _playerView;

        private List<ICollisionEnterListener> _onEnterlisteners = new List<ICollisionEnterListener>(5);
        private List<ICollisionExitListener> _onExitlisteners = new List<ICollisionExitListener>(5);

        public PlayerCollisionObserver(IÑollisionableView ñollisionableView)
        {
            _playerView = ñollisionableView;
            _playerView.OnCollisionEnter += OnPlayerCollisionEnter;
            _playerView.OnCollisionExit += OnPlayerCollisionExit;
            
        }

        private void OnPlayerCollisionEnter(Collision2D collision)
        {
            for(int i = 0; i < _onEnterlisteners.Count; i++)
            {
                _onEnterlisteners[i].OnPlayerCollisionEnter(collision);
            }
        }

        private void OnPlayerCollisionExit(Collision2D collision)
        {
            for (int i = 0; i < _onExitlisteners.Count; i++)
            {
                _onExitlisteners[i].OnPlayerCollisionExit(collision);
            }
        }

        public void Subscribe(ICollisionListener listener)
        {
            if (listener is ICollisionEnterListener enterListener)
            {
                _onEnterlisteners.Add(enterListener);
            }

            if (listener is ICollisionExitListener exitListener)
            {
                _onExitlisteners.Add(exitListener);
            }
        }

        public void Unsubscribe(ICollisionListener listener)
        {
            if (listener is ICollisionEnterListener enterListener)
            {
                _onEnterlisteners.Remove(enterListener);
            }

            if (listener is ICollisionExitListener exitListener)
            {
                _onExitlisteners.Remove(exitListener);
            }
        }

        public void Dispose()
        {
            _playerView.OnCollisionEnter -= OnPlayerCollisionEnter;
            _onExitlisteners.Clear();
        }
    }
}