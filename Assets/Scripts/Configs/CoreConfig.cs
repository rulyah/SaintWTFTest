using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CoreConfig", menuName = "Configs/CoreConfig")]

    public class CoreConfig : ScriptableObject
    {
        public float exchangeDelay = 0.5f;
    }
}