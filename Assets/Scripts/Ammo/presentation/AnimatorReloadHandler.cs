using System;
using UniRx;
using UnityEngine;
using static Ammo.presentation.IReloadHandler;

namespace Ammo.presentation
{
    public class AnimatorReloadHandler : MonoBehaviour, IReloadHandler
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string startTrigger = "start_reloading";
        [SerializeField] private string abortTrigger = "abort_reloading";

        private readonly Subject<ReloadingHandlerResult> handlerResultSubject = new();

        IObservable<ReloadingHandlerResult> IReloadHandler.StartReloading()
        {
            animator.SetTrigger(startTrigger);
            return handlerResultSubject.Take(1);
        }

        void IReloadHandler.AbortReloading()
        {
            animator.SetTrigger(abortTrigger);
            handlerResultSubject.OnNext(ReloadingHandlerResult.Aborted);
        }

        public void AnimationCompleteReloading() => handlerResultSubject.OnNext(ReloadingHandlerResult.Completed);
    }
}