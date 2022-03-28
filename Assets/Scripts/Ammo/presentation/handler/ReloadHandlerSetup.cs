using UnityEngine;
using Zenject;

namespace Ammo.presentation.handler
{
    public class ReloadHandlerSetup : MonoBehaviour
    {
        [Inject] private ReloadingNavigator navigator;
        private IReloadHandler handler;
        private void Awake() => handler = GetComponent<IReloadHandler>();

        private void OnEnable()
        {
            if (handler == null)
                Debug.LogError("Reload handler setup failed - handler not found!");

            navigator.SetReloadHandler(handler);
        }
    }
}