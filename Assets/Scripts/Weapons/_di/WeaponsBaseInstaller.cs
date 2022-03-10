using UnityEngine;
using Weapons.data;
using Weapons.data.dao;
using Weapons.domain;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons._di
{
    [CreateAssetMenu(fileName = "WeaponsBaseInstaller", menuName = "Installers/WeaponsBaseInstaller")]
    public class WeaponsBaseInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private WeaponEntitiesSODao weaponEntitiesSoDao;

        public override void InstallBindings()
        {
            //Data
            Container.Bind<IWeaponEntitiesDao>().FromInstance(weaponEntitiesSoDao).AsSingle();
            Container.Bind<IWeaponsRepository>().To<WeaponsRepository>().AsSingle();
            Container.Bind<ISelectedWeaponRepository>().To<SelectedWeaponInMemoryRepository>().AsSingle();
            Container.Bind<IWeaponPreviewRepository>().To<WeaponPreviewRepository>().AsSingle();
            Container.Bind<IWeaponPrefabRepository>().To<WeaponPrefabRepository>().AsSingle();
            //Domain
            Container.Bind<ScrollWeaponsUseCase>().ToSelf().AsSingle();
            Container.Bind<SelectWeaponUseCase>().ToSelf().AsSingle();
        }
    }
}