using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Models;
using Services.Factory;
using UnityEngine;
using Views;

namespace Controllers
{
    public class StorageController : MonoBehaviour
    {
        [SerializeField] private StorageView _storageView;
        [SerializeField] private StorageConfig _config;
        [SerializeField] private FactoryService _factory;
        [SerializeField] private TriggerController _trigger;
        [SerializeField] private WarningController _warningController;
        
        private StorageModel _model;
        
        public event Action<StorageController> onStartCollision;
        public event Action onStopCollision;
        private void Awake()
        {
            _model = new StorageModel();
            _trigger.onStartCollision += OnStartCollision;
            _trigger.onStopCollision += OnStopCollision;
        }

        private void OnStartCollision()
        {
            onStartCollision?.Invoke(this);
        }
        
        private void OnStopCollision()
        {
            onStopCollision?.Invoke();
        }
        
        public bool DoesHavePlace()
        {
            var capacityResources = _model.haveResources.Sum(resource => resource.count);
            if (capacityResources >= _config.capacityResources) return false;
            return true;
        }

        public bool DoesHaveResource(List<Resource> resources)
        {
            foreach (Resource resource in resources)
            {
                var item = _model.haveResources.Find(n => n.type == resource.type);
                if (item == null) return false;
                if (item.count <= 0) return false;
            }
            return true;
        }

        public void TakeResource(ResourceView resource)
        {
            var item = _model.haveResources.Find(n => n.type == resource.type);
            if (item == null) _model.haveResources.Add(new Resource(resource.type, 1));
            else item.count++;
            
            _storageView.storage.TakeResource(resource);
            _warningController.ShowWarning("");
        }

        public void RemoveResource(List<Resource> resources)
        {
            foreach (Resource resource in resources)
            {
                _model.haveResources.Find(n => n.type == resource.type).count--;
            }
        }

        public void DestroyResource(ResourceView resource)
        {
            _factory.GetElementByType(resource.type).Release(resource);
            if(!DoesHaveResource(_config.haveResource)) _warningController.ShowWarning("Is empty");
        }

        public ResourceView GetResourceByType(int type)
        {
            return _storageView.storage.GiveResource(type);
        }
        
        public List<int> GetResourceType()
        {
            var resourceTypes = new List<int>();
            foreach (var resource in _config.haveResource)
            {
                resourceTypes.Add(resource.type);
            }
            return resourceTypes;
        }
    }
}