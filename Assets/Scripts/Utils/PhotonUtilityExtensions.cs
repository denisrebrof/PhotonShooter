using Photon.Pun;
using UnityEngine;

namespace Utils
{
    public static class PhotonUtilityExtensions
    {
        public static bool GetPlayerId(this MonoBehaviour component, out string playerId)
        {
            var view = component.GetComponentInParent<PhotonView>();
            if (view == null)
            {
                Debug.LogError("Can not find root PhotonView!");
                playerId = string.Empty;
                return false;
            }

            playerId = view.Owner.UserId;
            return true;
        }
    }
}