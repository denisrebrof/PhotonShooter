using System.Collections;
using ModestTree;
using Shooting.domain;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Utils.Photon;
using Weapons.domain.repositories;
using Zenject;

namespace Shooting.presentation.SimpleShooter
{
    public class SimplePlayerWeaponShooter : MonoBehaviour
    {
        [SerializeField] private UnityEvent onShoot;
        [Inject] private ISelectedWeaponRepository selectedWeaponRepository;
        [Inject] private ShootUseCase shootUseCase;

        private bool onCooldown;
        private float cooldownDuration;

        private string shooterId;

        private void Awake()
        {
            if (!selectedWeaponRepository.GetSelectedWeapon(out var weapon)) return;
            this.GetPlayerId(out shooterId);
            cooldownDuration = ((float) weapon.PerMinuteRate) / 60;
        }

        private void Update()
        {
            if (!Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) return;
            if (onCooldown || shooterId.IsEmpty()) return;
            StartCoroutine(ShootCoroutine());
        }

        private IEnumerator ShootCoroutine()
        {
            onCooldown = true;
            shootUseCase.Shoot(shooterId);
            onShoot.Invoke();
            yield return new WaitForSeconds(cooldownDuration);
            onCooldown = false;
        }
    }
}