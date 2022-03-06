using System;
using Weapons.domain.model;

namespace Weapons.domain.repositories
{
    public interface ISelectedWeaponRepository
    {
        bool GetSelectedWeapon(out Weapon weapon);
        IObservable<Weapon> GetSelectedWeaponFlow();
        void SetSelectedWeapon(long weaponId);
    }
}