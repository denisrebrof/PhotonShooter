using Photon.Pun;
using UnityEngine;

namespace MatchState.presentation
{
    public class MatchStateController : MonoBehaviourPun
    {
        bool startTimer = false;
        double timerIncrementValue;
        double startTime;
        [SerializeField] double timer = 20;

        private void Start()
        {
            if(!PhotonNetwork.InRoom) return;
            if (PhotonNetwork.IsMasterClient)
            {
                var customValue = new ExitGames.Client.Photon.Hashtable();
                startTime = PhotonNetwork.Time;
                startTimer = true;
                customValue.Add("StartTime", startTime);
                PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
            }
            else
            {
                startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
                startTimer = true;
            }
        }

        void Update()
        {
            if (!startTimer) return;
            timerIncrementValue = PhotonNetwork.Time - startTime;
            if (timerIncrementValue >= timer)
            {
                //Timer Completed
                //Do What Ever You What to Do Here
            }
        }
    }
}