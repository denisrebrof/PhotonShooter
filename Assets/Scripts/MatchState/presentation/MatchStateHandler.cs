using ExitGames.Client.Photon;
using MatchState.domain;
using MatchState.domain.model;
using Photon.Pun;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation
{
    public class MatchStateHandler : MonoBehaviourPun
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

            if (!PhotonNetwork.IsMasterClient)
            {
                TakeMatchParams();
                return;
            }

            InitializeMatchParams();
            HandleStateTimer();
        }

        private void InitializeMatchParams()
        {
            stateRepository.SetMatchState(MatchStates.Playing);
            var customValue = new Hashtable
            {
                {StartTimeKey, PhotonNetwork.Time},
                {StateKey, (int) matchInitialState}
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
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

        private void HandleStateTimer() => getMatchStateTimerUpdateRequestsFlowUseCase
            .GetMatchStateTimerUpdateRequestsFlow()
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