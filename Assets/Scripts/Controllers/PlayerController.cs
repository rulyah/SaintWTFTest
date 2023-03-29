using System.Linq;
using Configs;
using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private PlayerView _player;

        private PlayerModel _model;
        
        private void Awake()
        {
            _model = new PlayerModel();
        }
        
        public bool DoesHavePlace()
        {
            int resourceCount = 0;
            foreach (var resource in _model.resources)
            {
                resourceCount += resource.count;
            }
            return resourceCount < _config.capacityResources;
        }

        public bool DoesHaveResource(int resourceType)
        {
            return _model.resources.Any(n => n.type == resourceType && n.count > 0);
        }
        
        public void TakeResource(ResourceView resource)
        {
            var item = _model.resources.Find(n => n.type == resource.type);
            if (item == null) _model.resources.Add(new Resource(resource.type,1));
            else item.count++;
            
            _player.storage.TakeResource(resource);
        }
        
        public ResourceView GiveResource(int type)
        {
            _model.resources.Find(n => n.type == type).count--;
            return _player.storage.GiveResource(type);
        }
        
        private void Update()
        {
            _rigidbody.velocity = new Vector3
                (_joystick.Horizontal * _config.moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _config.moveSpeed);

            if (_joystick.Horizontal != 0.0f || _joystick.Vertical != 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }
        }
    }
}