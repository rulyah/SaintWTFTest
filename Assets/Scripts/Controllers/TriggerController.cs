using System;
using UnityEngine;

namespace Controllers
{
    public class TriggerController : MonoBehaviour
    {
        public event Action onStartCollision;
        public event Action onStopCollision;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onStartCollision?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onStopCollision?.Invoke();
            }
        }
    }
}