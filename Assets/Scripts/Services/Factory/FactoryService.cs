using System.Collections.Generic;
using UnityEngine;
using Utils.FactoryTool;
using Views;

namespace Services.Factory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private List<ResourceView> _resources;

        public Factory<ResourceView> firstResource { get; private set; }
        public Factory<ResourceView> secondResource { get; private set; }
        public Factory<ResourceView> thirdResource { get; private set; }

        public Factory<ResourceView> GetElementByType(int type)
        {
            return type switch
            {
                0 => firstResource,
                1 => secondResource,
                _ => thirdResource
            };
        }

        private void Awake()
        {
            firstResource = new Factory<ResourceView>(_resources[0], 50);
            secondResource = new Factory<ResourceView>(_resources[1], 50);
            thirdResource = new Factory<ResourceView>(_resources[2], 50);
        }

        private void OnDestroy()
        {
            firstResource.Dispose();
            secondResource.Dispose();
            thirdResource.Dispose();
        }
    }
}
