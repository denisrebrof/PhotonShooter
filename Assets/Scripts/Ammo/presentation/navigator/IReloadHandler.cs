using System;

namespace Ammo.presentation.navigator
{
    public interface IReloadHandler
    {
        IObservable<ReloadingHandlerResult> StartReloading();
        void AbortReloading();

        public enum ReloadingHandlerResult
        {
            Completed,
            Aborted,
            InvalidState
        }
    }
}