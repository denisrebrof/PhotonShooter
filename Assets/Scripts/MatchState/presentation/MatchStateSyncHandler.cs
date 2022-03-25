using ExitGames.Client.Photon;
using MatchState.domain;
using MatchState.domain.model;
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
        [Inject] private GetMatchStateTimerUpdateRequestsFlowUseCase getMatchStateTimerUpdateRequestsFlowUseCase;

        [SerializeField] private MatchStates matchInitialState = MatchStates.Playing;

        private const string StartTimeKey = "StartTime";
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
            var customValue = new Hashtable
            {
                { StartTimeKey, PhotonNetwork.Time },
                { StateKey, (int)matchInitialState }
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
            startMatchStateUseCase.StartMatchState(matchInitialState);
        }

        private void TakeMatchParams()
        {
            //Apply match state
            var currentMatchState = (MatchStates) int.Parse(GetRoomCustomProperty(StateKey));
            stateRepository.SetMatchState(currentMatchState);
            //Apply timer
            var startTime = double.Parse(GetRoomCustomProperty(StartTimeKey));
            var timeLeft = PhotonNetwork.Time - startTime;
            timerRepository.StartTimer((int) timeLeft);
        }

        private void HandleMatchStateUpdates() => getMatchStateTimerUpdateRequestsFlowUseCase
            .GetMatchStateTimerUpdateRequestsFlow()
            .Where(_ => PhotonNetwork.IsMasterClient)
            .Subscribe(nextState =>
                photonView.RPC(nameof(RPC_ApplyMatchStateUpdate), RpcTarget.All, (int) nextState)
            ).AddTo(this);

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