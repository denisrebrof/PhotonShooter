using System;

namespace Ammo.presentation.handler
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