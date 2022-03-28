using System;
using UniRx;
using UnityEngine;
using static Ammo.presentation.handler.IReloadHandler;

namespace Ammo.presentation.handler
{
    public class AnimatorReloadHandler: MonoBehaviour, IReloadHandler
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string startTrigger = "start_reloading";
        [SerializeField] private string abortTrigger = "abort_reloading";

        private readonly Subject<ReloadingHandlerResult> handlerResultSubject = new();

        IObservable<ReloadingHandlerResult> IReloadHandler.StartReloading()
        {
            if (animator == null) return Observable.Return(ReloadingHandlerResult.InvalidState);
            animator.SetTrigger(startTrigger);
            return handlerResultSubject.Take(1);
        }

        void IReloadHandler.AbortReloading()
        {
            if (animator == null) return;
            animator.SetTrigger(abortTrigger);
            handlerResultSubject.OnNext(ReloadingHandlerResult.Aborted);
        }

        public void AnimationCompleteReloading() => handlerResultSubject.OnNext(ReloadingHandlerResult.Completed);
    }
}