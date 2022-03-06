﻿using System;
using Ammo.domain;
using Ammo.domain.model;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ammo.presentation
{
    public class ReloadingNavigator
    {
        [Inject] private ReloadAmmoUseCase reloadAmmoUseCase;
        [Inject] private IAmmoStateRepository ammoStateRepository;
        [Inject] private AmmoAvailableStateUseCase ammoAvailableStateUseCase;

        [CanBeNull] private IReloadHandler reloadHandler;

        public IObservable<ReloadingResult> StartReloading()
        {
            if (reloadHandler == null) return Observable.Return(ReloadingResult.WrongState);

            var currentState = ammoStateRepository.GetAmmoState();
            var reloadableAmmoState = currentState is AmmoState.Empty or AmmoState.Loaded;
            var ammoAvailableState = ammoAvailableStateUseCase.GetAmmoAvailableState();
            if (!reloadableAmmoState || !ammoAvailableState) return Observable.Return(ReloadingResult.WrongState);

            return reloadHandler.StartReloading().Select(GetReloadingResult);
        }

        private static ReloadingResult GetReloadingResult(IReloadHandler.ReloadingHandlerResult handlerResult)
        {
            ReloadingResult reloadingResult;
            switch (handlerResult)
            {
                case IReloadHandler.ReloadingHandlerResult.Completed:
                    reloadingResult = ReloadingResult.Success;
                    break;
                case IReloadHandler.ReloadingHandlerResult.Aborted:
                    reloadingResult = ReloadingResult.Stopped;
                    break;
                default:
                    Debug.LogError("IReloadPresenter.ReloadingPresenterResult out of range");
                    reloadingResult = ReloadingResult.Stopped;
                    break;
            }

            return reloadingResult;
        }

        public void SetReloadPresenter(IReloadHandler handler)
        {
            reloadHandler?.AbortReloading();
            reloadHandler = handler;
        }

        public enum ReloadingResult
        {
            Success,
            Stopped,
            WrongState
        }
    }
}