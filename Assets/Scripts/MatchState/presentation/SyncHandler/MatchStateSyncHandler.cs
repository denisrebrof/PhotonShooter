using MatchState.domain;
using MatchState.domain.model;
using Photon.Pun;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation.SyncHandler
{
    public class MatchStateSyncHandler : MonoBehaviourPun
    {
        [Inject] private RoomMatchStateParamsNavigator stateParamsNavigator;

        [Inject] private StartMatchStateUseCase startMatchStateUseCase;
        [Inject] private MatchStateUpdatesUseCase matchStateUpdatesUseCase;

        [SerializeField] private MatchStates matchInitialState = MatchStates.Playing;

        private void Start()
        {
            if (!PhotonNetwork.InRoom) return;

            if (PhotonNetwork.IsMasterClient)
            {
                stateParamsNavigator.UpdateStateParams(matchInitialState);
                startMatchStateUseCase.StartMatchState(matchInitialState);
            }
            else
            {
                var matchParams = stateParamsNavigator.GetStateParams();
                startMatchStateUseCase.StartMatchState(matchParams.CurrentState, matchParams.TimeLeft);
            }

            matchStateUpdatesUseCase
                .GetUpdatesFlow()
                .Subscribe(UpdateRoomMatchState)
                .AddTo(this);
        }

        private void UpdateRoomMatchState(MatchStates state)
        {
            if (!PhotonNetwork.IsMasterClient) return;
            stateParamsNavigator.UpdateStateParams(state);
            startMatchStateUseCase.StartMatchState(state);
            photonView.RPC(nameof(RPC_StartState), RpcTarget.Others, (int) state);
        }

        [PunRPC]
        public void RPC_StartState(int nextState) => startMatchStateUseCase.StartMatchState((MatchStates) nextState);
    }
}