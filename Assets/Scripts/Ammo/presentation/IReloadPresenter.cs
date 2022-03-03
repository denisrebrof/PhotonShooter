using System;

namespace Ammo.presentation
{
    public interface IReloadPresenter
    {
        IObservable<ReloadingPresenterResult> StartReloading();
        void AbortReloading();

        public enum ReloadingPresenterResult
        {
            Completed,
            Aborted
        }
    }
}