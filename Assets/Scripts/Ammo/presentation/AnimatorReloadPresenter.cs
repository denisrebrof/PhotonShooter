using System;
using UniRx;
using UnityEngine;
using static Ammo.presentation.IReloadPresenter;

namespace Ammo.presentation
{
    public class AnimatorReloadPresenter : MonoBehaviour, IReloadPresenter
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string startTrigger = "start_reloading";
        [SerializeField] private string abortTrigger = "abort_reloading";

        private readonly Subject<ReloadingPresenterResult> presenterResultSubject = new();

        IObservable<ReloadingPresenterResult> IReloadPresenter.StartReloading()
        {
            animator.SetTrigger(startTrigger);
            return presenterResultSubject.Take(1);
        }

        void IReloadPresenter.AbortReloading()
        {
            animator.SetTrigger(abortTrigger);
            presenterResultSubject.OnNext(ReloadingPresenterResult.Aborted);
        }

        public void AnimationCompleteReloading() => presenterResultSubject.OnNext(ReloadingPresenterResult.Completed);
    }
}