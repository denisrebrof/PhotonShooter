using System;
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

        [CanBeNull] private IReloadPresenter reloadPresenter;

        public IObservable<ReloadingResult> StartReloading()
        {
            if (reloadPresenter == null) return Observable.Return(ReloadingResult.WrongState);

            var currentState = ammoStateRepository.GetAmmoState();
            var reloadableAmmoState = currentState is AmmoState.Empty or AmmoState.Loaded;
            var ammoAvailableState = ammoAvailableStateUseCase.GetAmmoAvailableState();
            if (!reloadableAmmoState || !ammoAvailableState) return Observable.Return(ReloadingResult.WrongState);

            return reloadPresenter.StartReloading().Select(GetReloadingResult);
        }

        private static ReloadingResult GetReloadingResult(IReloadPresenter.ReloadingPresenterResult presenterResult)
        {
            ReloadingResult reloadingResult;
            switch (presenterResult)
            {
                case IReloadPresenter.ReloadingPresenterResult.Completed:
                    reloadingResult = ReloadingResult.Success;
                    break;
                case IReloadPresenter.ReloadingPresenterResult.Aborted:
                    reloadingResult = ReloadingResult.Stopped;
                    break;
                default:
                    Debug.LogError("IReloadPresenter.ReloadingPresenterResult out of range");
                    reloadingResult = ReloadingResult.Stopped;
                    break;
            }

            return reloadingResult;
        }

        public void SetReloadPresenter(IReloadPresenter presenter)
        {
            reloadPresenter?.AbortReloading();
            reloadPresenter = presenter;
        }

        public enum ReloadingResult
        {
            Success,
            Stopped,
            WrongState
        }
    }
}