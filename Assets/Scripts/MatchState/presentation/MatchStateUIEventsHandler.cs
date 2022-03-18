using System;
using Doozy.Engine;
using MatchState.domain;
using MatchState.domain.model;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation
{
    public class MatchStateUIEventsHandler : MonoBehaviour
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [SerializeField] private string playingStateEvent = "PlayingState";
        [SerializeField] private string resultsStateEvent = "ResultsState";

        private void Start() => matchStateRepository
            .GetMatchStateFlow()
            .Subscribe(OnMatchStateUpdates)
            .AddTo(this);

        private void OnMatchStateUpdates(MatchStates state)
        {
            if (state == MatchStates.Playing)
                new GameEventMessage(playingStateEvent).Send();
            else
                new GameEventMessage(resultsStateEvent).Send();
        }
    }
}