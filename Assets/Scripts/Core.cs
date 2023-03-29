using System;
using System.Collections;
using Configs;
using Controllers;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private PlantController[] _plants;
    [SerializeField] private PlayerController _player;
    [SerializeField] private CoreConfig _config;
    private Coroutine _coroutine;
    private void Awake()
    {
        foreach (var plant in _plants)
        {
            plant.shop.onStartCollision += OnShopCollision;
            plant.shop.onStopCollision += StopExchange;

            plant.storage.onStartCollision += OnStorageCollision;
            plant.storage.onStopCollision += StopExchange;
        }
    }
    
    private void OnStorageCollision(StorageController storage)
    {
        _coroutine = StartCoroutine(Exchange(_config.exchangeDelay, () =>
        {
            var resourceTypes = storage.GetResourceType();
            
            for (var i = 0; i < resourceTypes.Count; i++)
            {
                if (storage.DoesHavePlace() && _player.DoesHaveResource(resourceTypes[i]))
                {
                    var resource = _player.GiveResource(resourceTypes[i]);
                    storage.TakeResource(resource);
                }
            }
        }));
    }

    private void OnShopCollision(ShopController shop)
    {
        _coroutine = StartCoroutine(Exchange(_config.exchangeDelay, () =>
        {
            if (!shop.DoesHaveResource()) return;
            if (!_player.DoesHavePlace()) return;
            var resource = shop.RemoveResource();
            _player.TakeResource(resource);
        }));
    }

    private void StopExchange()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Exchange(float waitTime, Action action)
    {
        while (true)
        {
            action?.Invoke();
            yield return new WaitForSeconds(waitTime);
        }
    }
}