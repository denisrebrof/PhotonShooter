using ExitGames.Client.Photon;
using MatchState.domain;
using MatchState.domain.model;
using MatchState.domain.repositories;
using Photon.Pun;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation
{
    public class MatchStateSyncHandler : MonoBehaviourPun
    {
        [Inject] private IMatchStateRepository stateRepository;
        [Inject] private IMatchTimerRepository timerRepository;
        [Inject] private StartMatchStateUseCase startMatchStateUseCase;
        [Inject] private GetMatchStateTimerUpdatesUseCase getMatchStateTimerUpdatesUseCase;

        [SerializeField] private MatchStates matchInitialState = MatchStates.Playing;

        private const string StartStateTimeKey = "StartTime";
        private const string StateKey = "StateKey";

        private void Start()
        {
            if (!PhotonNetwork.InRoom) return;

            if (PhotonNetwork.IsMasterClient)
                InitializeMatchParams();
            else
                TakeMatchParams();

            HandleMatchStateUpdates();
        }

        private void InitializeMatchParams()
        {
            SetCurrentStateMatchParams(matchInitialState);
            startMatchStateUseCase.StartMatchState(matchInitialState);
        }

        private void TakeMatchParams()
        {
            //Apply match state
            var currentMatchState = (MatchStates) int.Parse(GetRoomCustomProperty(StateKey));
            stateRepository.SetMatchState(currentMatchState);
            //Apply timer
            var startTime = double.Parse(GetRoomCustomProperty(StartStateTimeKey));
            var timeLeft = PhotonNetwork.Time - startTime;
            timerRepository.StartTimer((int) timeLeft);
        }

        private static void SetCurrentStateMatchParams(MatchStates state)
        {
            var customValue = new Hashtable
            {
                { StartStateTimeKey, PhotonNetwork.Time },
                { StateKey, (int)state }
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
        }

        private void HandleMatchStateUpdates() => getMatchStateTimerUpdatesUseCase
            .GetMatchStateTimerUpdateRequestsFlow()
            .Where(_ => PhotonNetwork.IsMasterClient)
            .Do(SetCurrentStateMatchParams)
            .Subscribe(ApplyMatchStateUpdate)
            .AddTo(this);

        private void ApplyMatchStateUpdate(MatchStates state)
        {
            photonView.RPC(nameof(RPC_ApplyMatchStateUpdate), RpcTarget.All, (int)state);
        }

        [PunRPC]
        public void RPC_ApplyMatchStateUpdate(int nextState)
        {
            startMatchStateUseCase.StartMatchState((MatchStates) nextState);
        }

        private static string GetRoomCustomProperty(string key) => PhotonNetwork
            .CurrentRoom
            .CustomProperties[key]
            .ToString();
    }
}