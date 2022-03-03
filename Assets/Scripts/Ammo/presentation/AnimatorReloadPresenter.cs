using System;
using UnityEngine;
using Zenject;

namespace Ammo.presentation
{
    public class AnimatorReloadPresenter: MonoBehaviour, IReloadPresenter
    {
        [Inject] private ReloadingNavigator navigator;
        
        public IObservable<IReloadPresenter.ReloadingPresenterResult> StartReloading()
        {
            
        }

        public void AbortReloading()
        {
            
        }
    }
}