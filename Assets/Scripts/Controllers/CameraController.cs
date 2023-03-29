using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        private Vector3 _offset;

        private void Start()
        {
            _offset = _playerTransform.position - transform.position;
        }

        private void Update()
        {
            transform.position = _playerTransform.position - _offset;
        }
    }
}