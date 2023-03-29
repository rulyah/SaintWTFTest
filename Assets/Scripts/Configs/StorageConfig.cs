using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "StorageConfig", menuName = "Configs/StorageConfig")]

    public class StorageConfig : ScriptableObject
    {
        public List<Resource> haveResource;
        public int capacityResources;
    }
}