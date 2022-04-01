using MatchState.domain;
using MatchState.domain.model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static MatchState.domain.GetTimerStateFlowUseCase;

namespace MatchState.presentation.UI
{
    public class MatchTimerView : MonoBehaviour
    {
        [Inject] private GetTimerStateFlowUseCase getTimerStateFlowUseCase;

        [SerializeField, Tooltip("$ sign will be replaced with mm:ss timer")]
        private string template = "$";

        [SerializeField] private Text timerText;
        [SerializeField] private MatchStates observedState;

        private void Start() => getTimerStateFlowUseCase
            .GetTimerStateFlow(observedState)
            .Subscribe(HandleTimerState)
            .AddTo(this);

        private void HandleTimerState(TimerState state)
        {
            timerText.enabled = state.IsActive;
            if (!template.Contains('$'))
            {
                Debug.LogError("Timer text template does not contains '$' to replace!");
                return;
            }

            var minutes = state.TimeLeft / 60;
            var seconds = state.TimeLeft % 60;
            timerText.text = template.Replace("$", $"{minutes}:{seconds}");
        }
    }
}