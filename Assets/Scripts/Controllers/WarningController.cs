using UnityEngine;
using Views;

namespace Controllers
{
    public class WarningController : MonoBehaviour
    {
        [SerializeField] private WarningView _view;

        public void ShowWarning(string text)
        {
            _view.SetMessage(text);
            _view.gameObject.SetActive(!string.IsNullOrEmpty(text));
        }
        
    }
}