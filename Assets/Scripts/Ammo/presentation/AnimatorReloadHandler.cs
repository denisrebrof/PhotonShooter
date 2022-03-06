using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using static Ammo.presentation.IReloadHandler;

namespace Ammo.presentation
{
    public class AnimatorReloadHandler: IReloadHandler
    {
        [CanBeNull] private Animator animator;
        private string startTrigger;
        private string abortTrigger;

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

        public void SetAnimator(Animator newAnimator, string sTrigger, string eTrigger)
        {
            if (animator != null)
                handlerResultSubject.OnNext(ReloadingHandlerResult.Aborted);
            
            animator = newAnimator;
            startTrigger = sTrigger;
            abortTrigger = eTrigger;
        }
    }
}