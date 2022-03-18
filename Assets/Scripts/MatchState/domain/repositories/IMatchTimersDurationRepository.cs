namespace MatchState.domain.repositories
{
    public interface IMatchTimersDurationRepository
    {
        int MatchDuration { get; }
        int RestartDuration { get; }
    }
}