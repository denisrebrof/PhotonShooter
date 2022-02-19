using UnityEngine;

namespace Photon.Gameplay
{
    public class PlayerInputSetup : MonoBehaviour
    {
        [SerializeField] private FirstPersonLook look;
        [SerializeField] private GroundCheck check;
        [SerializeField] private Jump jump;

        private void OnEnable()
        {
        }
    }
}