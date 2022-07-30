using UnityEngine;
using UnityEngine.UI;

namespace RH.Utilities.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseActionButton : MonoBehaviour
    {
        private Button _button { get; set; }

        protected abstract void PerformOnClick();
        protected virtual void PerformOnStart() {}

        private void Start()
        {
            _button = GetComponent<Button>();
            
            PerformOnStart();
            
            _button.onClick.AddListener(PerformOnClick);
        }

        private void OnDestroy()
        {
            _button?.onClick.RemoveListener(PerformOnClick);
        }
    }
}