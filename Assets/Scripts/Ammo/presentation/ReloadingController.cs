using System;
using Ammo.presentation.navigator;
using CharacterInput.domain;
using CharacterInput.domain.model;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ammo.presentation
{
    public class ReloadingController: MonoBehaviour
    {
        
        [Inject] private ReloadNavigator navigator;
        [Inject] private CharacterInputUseCase inputUseCase;

        private void Update()
        {
            if (!(inputUseCase.GetAxis(CharacterInputAxis.Reload) > 0f)) return;
            
            navigator.StartReloading().Subscribe().AddTo(this);
        }
    }
}