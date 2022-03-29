using UnityEngine;
using Weapons.domain;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.presentation
{
    public class DefaultWeaponSelector : MonoBehaviour
    {
        [Inject] private DefaultWeaponUseCase defaultWeaponUseCase;
        [Inject] private ISelectedWeaponRepository repository;
        // Start is called before the first frame update
        private void Start()
        {
            var defaultWeapon = defaultWeaponUseCase.GetDefaultWeapon();
            repository.SetSelectedWeapon(defaultWeapon.ID);
        }
    }
}
