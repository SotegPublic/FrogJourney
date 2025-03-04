using System;

namespace Platformer.Core
{
    public class BaseSubscribableProperty<T>
    {
        protected Action<T> _onPropertyChange;
        protected T _value;

        protected void SetValue(T value)
        {
            _value = value;
            _onPropertyChange?.Invoke(_value);
        }

        public void Subscribe(Action<T> subscribingAction)
        {
            _onPropertyChange += subscribingAction; 
        }

        public void Unsubscribe(Action<T> unsubscribingAction)
        {
            _onPropertyChange -= unsubscribingAction;
        }
    }
}
