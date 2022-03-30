using System;
using Ammo.presentation.navigator;
using UniRx;
using UnityEngine;
using Weapons.presentation.utils;
using Zenject;

namespace Ammo.presentation
{
    public class ReloadingController: MonoBehaviour
    {
        [Inject] private ReloadNavigator navigator;

        private void Start() => Observable.EveryUpdate().Subscribe(_ => HandleReloadInput()).AddTo(this);
        
        private void HandleReloadInput()
        {
            if (!Input.GetKeyDown(KeyCode.R)) return;
            navigator.StartReloading().Subscribe(result => Debug.Log(result)).AddTo(this);
        }
    }
}