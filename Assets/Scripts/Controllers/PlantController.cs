using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Controllers
{
    public class PlantController : MonoBehaviour
    {
        [SerializeField] private PlantConfig _config;
        [SerializeField] private ShopController _shop;
        [SerializeField] private StorageController _storage;
        [SerializeField] private Transform _consumingParent;

        public ShopController shop => _shop;
        public StorageController storage => _storage;

        private void Start()
        {
            StartCoroutine(Working());
        }

        private IEnumerator Working()
        {
            while (true)
            {
                if (!CanProduce())
                {
                    yield return null;
                    continue;
                }
                
                yield return ConsumingResources(_config.consumingResources);
                yield return ProduceGood();
            }
        }

        public IEnumerator ConsumingResources(List<Resource> resources)
        {
            _storage.RemoveResource(resources);
            foreach (var resource in resources)
            {
                var item = _storage.GetResourceByType(resource.type);
                item.transform.SetParent(_consumingParent);
                item.MoveToParent(_consumingParent.position.y, () =>
                {
                    _storage.DestroyResource(item);
                });
                yield return new WaitForSeconds(_config.consumingResourceDelay);
            }
        }
        
        public IEnumerator ProduceGood()
        {
            yield return new WaitForSeconds(_config.plantDelayTime);
            _shop.Produce(_config.produceResource);
        }
        
        public bool CanProduce()
        {
            if (!_shop.DoesHavePlace()) return false;
            if (!_storage.DoesHaveResource(_config.consumingResources)) return false;
            return true;
        }
    }
}