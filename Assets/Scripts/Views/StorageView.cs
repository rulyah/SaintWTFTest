using UnityEngine;

namespace Views
{
    public class StorageView : MonoBehaviour
    {
        public Storage storage { get; private set; }

        private void Awake()
        {
            storage = new Storage(gameObject);
        }
    }
}