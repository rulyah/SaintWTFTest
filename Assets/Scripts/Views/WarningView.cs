using TMPro;
using UnityEngine;

namespace Views
{
    public class WarningView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private Camera _camera; 
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        public void SetMessage(string message)
        {
            _text.text = message;
        }

        private void Update()
        {
            var direction = Vector3.Normalize(transform.position - _camera.transform.position);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}