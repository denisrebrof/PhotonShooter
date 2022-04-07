using System;
using UnityEngine;
using Utils;
using Utils.Photon;
using Zenject;

namespace Shooting.presentation.SimpleShooter
{
    public class SimpleShooterPresenter: MonoBehaviour
    {
        // [Inject] private 
        private void Awake()
        {
            if(!this.GetPlayerId(out var shooterId)) return;
            
        }
    }
}