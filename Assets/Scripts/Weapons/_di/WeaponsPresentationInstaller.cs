using UnityEngine;
using Weapons.presentation.ui;
using Zenject;

namespace Weapons._di
{
    public class WeaponsPresentationInstaller : MonoInstaller
    {
        [SerializeField] private WeaponListItem listItemPrefab;

        public override void InstallBindings()
        {
            //UI
            Container.BindFactory<WeaponListItem, WeaponListItem.Factory>().FromComponentInNewPrefab(listItemPrefab);
        }
    }
}