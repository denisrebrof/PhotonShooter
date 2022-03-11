using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

namespace MatchState.presentation
{
    public class MatchStateHandler : MonoBehaviourPun
    {
        [SerializeField] double matchDurationTimer = 60;
        [SerializeField] double matchRestartTimer = 10;
        double startTime;

        private void Start()
        {
            if (!PhotonNetwork.InRoom) return;
            
            if (!PhotonNetwork.IsMasterClient)
            {
                startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
                return;
            }

            var customValue = new Hashtable();
            startTime = PhotonNetwork.Time;
            customValue.Add("StartTime", startTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
        }

        void Update()
        {
            timerIncrementValue = PhotonNetwork.Time - startTime;
            if (timerIncrementValue >= matchDurationTimer)
            {
                //Timer Completed
                //Do What Ever You What to Do Here
            }
        }
    }
}