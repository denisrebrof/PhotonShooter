using UnityEngine;
using Zenject;

namespace Ammo.presentation
{
    public class ReloadHandlerAnimatorProvider : MonoBehaviour
    {
        [Inject] private AnimatorReloadHandler animatorReloadHandler;
        [SerializeField] private Animator animator;
        [SerializeField] private string startTrigger = "start_reloading";
        [SerializeField] private string abortTrigger = "abort_reloading";

        private void Start() => animatorReloadHandler.SetAnimator(animator, startTrigger, abortTrigger);
    }
}