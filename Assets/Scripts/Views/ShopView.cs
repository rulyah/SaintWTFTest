using UnityEngine;

namespace Views
{
    public class ShopView : MonoBehaviour
    {
        public Storage storage { get; private set; }

        public void Awake()
        {
            storage = new Storage(gameObject);
        }
    }
}