using Platformer.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    public class PlayerCollisionObserver: IDisposable
    {
        private IÑollisionableView _playerView;

        private List<IPlayerCollisionEnterListener> _onEnterlisteners = new List<IPlayerCollisionEnterListener>(5);
        private List<IPlayerCollisionExitListener> _onExitlisteners = new List<IPlayerCollisionExitListener>(5);

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

        public void Subscribe(IPlayerCollisionListener listener)
        {
            if (listener is IPlayerCollisionEnterListener enterListener)
            {
                _onEnterlisteners.Add(enterListener);
            }

            if (listener is IPlayerCollisionExitListener exitListener)
            {
                _onExitlisteners.Add(exitListener);
            }
        }

        public void Unsubscribe(IPlayerCollisionListener listener)
        {
            if (listener is IPlayerCollisionEnterListener enterListener)
            {
                _onEnterlisteners.Remove(enterListener);
            }

            if (listener is IPlayerCollisionExitListener exitListener)
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