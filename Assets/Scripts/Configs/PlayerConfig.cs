using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]

    public class PlayerConfig : ScriptableObject
    {
        public float moveSpeed;
        public int capacityResources;
    }
}