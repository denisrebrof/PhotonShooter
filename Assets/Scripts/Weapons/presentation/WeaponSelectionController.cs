using UniRx;
using UnityEngine;
using Utils;
using Weapons.domain;
using Zenject;
using static Weapons.domain.ScrollWeaponsUseCase;

namespace Weapons.presentation
{
    public class WeaponSelectionController : MonoBehaviour
    {
        [Inject] private SelectWeaponUseCase selectWeaponUseCase;
        [Inject] private ScrollWeaponsUseCase scrollWeaponsUseCase;
        [Inject] private IWeaponSelectionAvailableProvider selectionAvailableProvider;

        private void Start() => Observable.EveryUpdate().Subscribe(_ => HandleInput()).AddTo(this);

        private void HandleInput()
        {
            HandleScrollInput();
            HandleKeyInput();
        }

        private void HandleScrollInput()
        {
            var scrollDelta = Input.mouseScrollDelta.y;
            if (scrollDelta == 0) return;
            if (!selectionAvailableProvider.IsSelectionAvailable()) return;
            var direction = scrollDelta > 0 ? ScrollDirection.Next : ScrollDirection.Previous;
            scrollWeaponsUseCase.ScrollWeapon(direction);
        }

        private void HandleKeyInput()
        {
            if (!NumericInput.GetNumericInput(out var number)) return;
            if (!selectionAvailableProvider.IsSelectionAvailable()) return;
            selectWeaponUseCase.SelectWeapon(number);
        }

        public interface IWeaponSelectionAvailableProvider
        {
            public bool IsSelectionAvailable();
        }
    }
}