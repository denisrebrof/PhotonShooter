using System;
using Health.domain.repositories;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Health.presentation
{
    public class PhotonViewSceneHealthHandler: MonoBehaviour
    {
        [Inject] private IHealthHandlersRepository healthHandlersRepository;
        private void Start()
        {
            var view = GetComponentInParent<PhotonView>();
            if (view == null)
            {
                Debug.LogError("HealthSceneUI can not find root PhotonView!");
                return;
            }

            var userId = view.Owner.UserId;

        }
    }
}