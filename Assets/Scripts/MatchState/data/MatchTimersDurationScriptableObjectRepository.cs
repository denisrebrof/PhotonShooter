using MatchState.domain.repositories;
using UnityEngine;

namespace MatchState.data
{
    [
        CreateAssetMenu
        (
            fileName = "MatchTimersDurationScriptableObjectRepository",
            menuName = "Repositories/MatchTimersDurationScriptableObjectRepository",
            order = 0
        )
    ]
    public class MatchTimersDurationScriptableObjectRepository : ScriptableObject, IMatchTimersDurationRepository
    {
        [SerializeField] private int matchDurationTimer = 60;
        [SerializeField] private int matchRestartTimer = 10;

        public int MatchDuration => matchDurationTimer;
        public int RestartDuration => matchRestartTimer;
    }
}