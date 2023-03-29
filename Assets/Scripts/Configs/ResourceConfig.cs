using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ResourceConfig", menuName = "Configs/ResourceConfig")]

    public class ResourceConfig : ScriptableObject
    {
        public Resource resource;
        public float _moveTime;
    }
}