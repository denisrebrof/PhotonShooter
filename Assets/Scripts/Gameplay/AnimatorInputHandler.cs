using Photon.Pun;
using UnityEngine;

namespace Gameplay
{
    public class AnimatorInputHandler: MonoBehaviourPun
    {
        [SerializeField] private FirstPersonMovement movement;
        [SerializeField] private GroundCheck check;
        [SerializeField] private Animator animator;
        [SerializeField] private string horAxis = "horizontal";
        [SerializeField] private string verAxis = "vertical";
        [SerializeField] private string isRunningAxis = "run";
        [SerializeField] private string isJumpingAxis = "jumping";

        private void Update()
        {
            if(!photonView.IsMine || !PhotonNetwork.IsConnected)
                return;

            animator.SetFloat(horAxis, Input.GetAxis("Horizontal"));
            animator.SetFloat(verAxis, Input.GetAxis("Vertical"));
            animator.SetBool(isRunningAxis, movement.IsRunning);
            animator.SetBool(isJumpingAxis, !check.isGrounded);
        }
    }
}