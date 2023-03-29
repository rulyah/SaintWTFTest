using System;
using Configs;
using Models;
using Services.Factory;
using UnityEngine;
using Views;

namespace Controllers
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopView _shopView;
        [SerializeField] private ShopConfig _config;
        [SerializeField] private FactoryService _factory;
        [SerializeField] private TriggerController _trigger;
        [SerializeField] private WarningController _warningController;
        [SerializeField] private Transform _resourceSpawn;
        
        private ShopModel _model;
        
        public event Action<ShopController> onStartCollision;
        public event Action onStopCollision;

        private void Awake()
        {
            _model = new ShopModel(_config);
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
            return _model.haveResources.count < _config.capacityResources.count;
        }

        public bool DoesHaveResource()
        {
            return _model.haveResources.count > 0;
        }

        public void Produce(Resource resource)
        {
            _model.haveResources.count++;
            var item = _factory.GetElementByType(resource.type).Produce();
            item.transform.position = _resourceSpawn.position;
            _shopView.storage.TakeResource(item);

            if(DoesFull()) _warningController.ShowWarning("Is full");
        }

        public bool DoesFull()
        {
            if (_model.haveResources.count >= _config.capacityResources.count) return true;
            return false;
        }
        
        public ResourceView RemoveResource()
        {
            _model.haveResources.count--;
            _warningController.ShowWarning("");
            return _shopView.storage.GiveResource(_model.haveResources.type);
        }
    }
}