using UnityEngine;
using Zenject;

namespace Ammo.presentation
{
    public class ReloadPresenterSetup : MonoBehaviour
    {
        [Inject] private ReloadingNavigator navigator;
        private IReloadPresenter presenter;
        private void Awake() => presenter = GetComponent<IReloadPresenter>();

        private void OnEnable()
        {
            if (presenter == null)
                Debug.LogError("Reload presenter setup failed - presenter not found!");

            navigator.SetReloadPresenter(presenter);
        }
    }
}