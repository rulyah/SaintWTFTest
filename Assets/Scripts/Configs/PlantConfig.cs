using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlantConfig", menuName = "Configs/PlantConfig")]
    public class PlantConfig : ScriptableObject
    {
        public List<Resource> consumingResources;
        public Resource produceResource;
        public float plantDelayTime;
        public float consumingResourceDelay;
    }
}
