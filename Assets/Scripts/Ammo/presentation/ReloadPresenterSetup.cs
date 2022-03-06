using UnityEngine;
using Zenject;

namespace Ammo.presentation
{
    public class ReloadPresenterSetup : MonoBehaviour
    {
        [Inject] private ReloadingNavigator navigator;
        private IReloadHandler handler;
        private void Awake() => handler = GetComponent<IReloadHandler>();

        private void OnEnable()
        {
            if (handler == null)
                Debug.LogError("Reload presenter setup failed - presenter not found!");

            navigator.SetReloadPresenter(handler);
        }
    }
}