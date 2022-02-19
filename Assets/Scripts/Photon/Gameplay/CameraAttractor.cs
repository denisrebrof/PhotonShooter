using System;
using System.Collections;
using DG.Tweening;
using Photon.Pun;
using UnityEngine;

namespace Photon.Gameplay
{
    public class CameraAttractor : MonoBehaviourPun
    {
        private Transform cam;

        private void Start()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
                return;

            StartCoroutine(AttractCam());
        }

        private IEnumerator AttractCam()
        {
            cam = Camera.main.transform;
            var thisTransform = transform;
            var startPos = cam.position;
            var startRot = cam.rotation;
            var timer = 0f;
            while (timer < 3f)
            {
                cam.position = Vector3.Lerp(startPos, thisTransform.position, timer);
                cam.rotation = Quaternion.Slerp(startRot, thisTransform.rotation, timer);
                timer+=Time.deltaTime;
                yield return null;
            }

            cam.position = thisTransform.position;
            cam.rotation = thisTransform.rotation;
            cam.SetParent(thisTransform);
        }

        private void OnDestroy()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
                return;
            
            cam.SetParent(null);
        }
    }
}
