using ExitGames.Client.Photon;
using MatchState.domain;
using MatchState.domain.model;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace MatchState.presentation
{
    public class MatchStateHandler : MonoBehaviourPun
    {
        [Inject] private IMatchStateRepository stateRepository;
        [Inject] private IMatchTimerRepository timerRepository;
        [Inject] private MatchStateDurationUseCase stateDurationUseCase;
        [Inject] private StartMatchStateUseCase startMatchStateUseCase;

        [SerializeField] private MatchStates matchInitialState = MatchStates.Playing;

        const string StartTimeKey = "StartTime";
        const string StateKey = "StateKey";

        private void Start()
        {
            if (!PhotonNetwork.InRoom) return;

            if (PhotonNetwork.IsMasterClient) InitializeMatchParams();
            else TakeMatchParams();
        }

        private void InitializeMatchParams()
        {
            stateRepository.SetMatchState(MatchStates.Playing);
            var customValue = new Hashtable();
            customValue.Add(StartTimeKey, PhotonNetwork.Time);
            customValue.Add(StateKey, matchInitialState as int);
            PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
        }

        private void TakeMatchParams()
        {
            //Apply match state
            var currentMatchState = (MatchStates)int.Parse(GetRoomCustomProperty(StateKey));
            stateRepository.SetMatchState(currentMatchState);
            //Apply timer
            var startTime = double.Parse(GetRoomCustomProperty(StartTimeKey));
            var timeLeft = PhotonNetwork.Time - startTime;
            timerRepository.StartTimer((int)timeLeft);
        }

        private static string GetRoomCustomProperty(string key) => PhotonNetwork
            .CurrentRoom
            .CustomProperties[key]
            .ToString();
    }
}