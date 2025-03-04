using UnityEngine;

namespace Platformer.Core
{
    public class ObjectView<T> : MonoBehaviour where T : IObjectModel
    {
        [SerializeField] protected T _objectModel;

        public T ObjectModel => _objectModel;
    }
}
