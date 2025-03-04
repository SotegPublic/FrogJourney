using Platformer.Core;

namespace Platformer.Player
{
    public class HealthProperty: BaseSubscribableProperty<int>
    {
        public int GetHealth()
        {
            return _value;
        }

        public void AddHealth(int addedableValue)
        {
            var newValue = _value + addedableValue;
            SetValue(newValue);
        }

        public void RemoveHealth(int removableValue)
        {
            var newValue = _value - removableValue;

            if(newValue < 0)
            {
                SetValue(0);
            }
            else
            {
                SetValue(newValue);
            }
        }
    }
}
