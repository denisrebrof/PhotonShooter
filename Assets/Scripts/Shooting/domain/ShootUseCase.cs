using Ammo.domain;
using Shooting.domain.model;
using Zenject;

namespace Shooting.domain
{
    public class ShootUseCase
    {
        [Inject] private IShootingRepository repository;
        [Inject] private PassAmmoUseCase passAmmoUseCase;

        public bool Shoot(string shooterID)
        {
            var passResult = passAmmoUseCase.Pass(1);
            if (passResult != PassAmmoUseCase.PassAmmoResult.Success) return false;
            repository.AddShoot(new Shoot(shooterID));
            return true;
        }
    }
}