using System.Collections.Generic;
using MatchState.domain.model;
using MatchState.domain.repositories;
using Zenject;

namespace MatchState.domain
{
    public class MatchStateDurationUseCase
    {
        private readonly Dictionary<MatchStates, int> statesToDurations;

        [Inject]
        public MatchStateDurationUseCase(IMatchTimersDurationRepository timersDurationRepository)
        {
            statesToDurations = new Dictionary<MatchStates, int>
            {
                { MatchStates.Finished, timersDurationRepository.RestartDuration },
                { MatchStates.Playing, timersDurationRepository.MatchDuration },
            };
        }

        public bool HasStateDuration(MatchStates state) => statesToDurations.ContainsKey(state);

        public bool GetStateDurationIfItHas(MatchStates state, out int duration)
        {
            if (!HasStateDuration(state))
            {
                duration = 0;
                return false;
            }

            duration = statesToDurations[state];
            return true;
        }
    }
}