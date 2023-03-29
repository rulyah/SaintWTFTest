using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/ShopConfig")]
    public class ShopConfig : ScriptableObject
    {
        public Resource capacityResources;
    }
}