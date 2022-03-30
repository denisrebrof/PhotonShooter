using Ammo.presentation;
using Ammo.presentation.navigator;
using UnityEngine;
using Weapons.presentation;
using Zenject;

namespace Ammo._di
{
    public class AmmoPresentationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ReloadNavigator>().ToSelf().AsSingle();

            Container
                .Bind<WeaponSelectionController.IWeaponSelectionAvailableProvider>()
                .To<ReloadWeaponSelectionAvailableProvider>().AsSingle();
        }
    }
}