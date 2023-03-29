using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject _baggage;
        
        public Storage storage { get; private set; }

        private void Awake()
        {
            storage = new Storage(_baggage);
        }
    }
}