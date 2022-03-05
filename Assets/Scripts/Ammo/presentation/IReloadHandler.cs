using System;

namespace Ammo.presentation
{
    public interface IReloadHandler
    {
        IObservable<ReloadingHandlerResult> StartReloading();
        void AbortReloading();

        public enum ReloadingHandlerResult
        {
            Completed,
            Aborted
        }
    }
}