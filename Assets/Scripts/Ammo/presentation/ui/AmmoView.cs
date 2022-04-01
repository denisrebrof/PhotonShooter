using Ammo.domain;
using Ammo.domain.repository;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Weapons.domain.repositories;
using Zenject;

namespace Ammo.presentation.ui
{
    public class AmmoView : MonoBehaviour
    {
        [SerializeField] private Text ammoText;
        [SerializeField] private GameObject reloadingIndicator;
        [SerializeField] private GameObject reloadRequiredIndicator;
        
        [Inject] private ISelectedWeaponRepository selectedWeaponRepository;
        [Inject] private IAmmoRepository ammoRepository;
        [Inject] private AmmoAvailableStateUseCase availableStateUseCase;
        [Inject] private GetReloadingStateUseCase reloadingStateUseCase;
        [Inject] private GetReloadRequiredStateUseCase reloadRequiredStateUseCase;

        private void Start()
        {
            availableStateUseCase.GetAmmoAvailableStateFlow().Subscribe(ammoText.gameObject.SetActive).AddTo(this);
            reloadingStateUseCase.GetIsReloadingFlow().Subscribe(reloadingIndicator.SetActive).AddTo(this);
            reloadRequiredStateUseCase.GetReloadRequiredFlow().Subscribe(reloadRequiredIndicator.SetActive).AddTo(this);
            Observable.CombineLatest(
                ammoRepository.GetLoadedAmmoCountFlow(),
                selectedWeaponRepository.GetSelectedWeaponFlow(),
                (ammo, weapon) => ammo + "/" + weapon.AmmoCapacity
            ).Subscribe(text => ammoText.text = text).AddTo(this);
        }
    }
}