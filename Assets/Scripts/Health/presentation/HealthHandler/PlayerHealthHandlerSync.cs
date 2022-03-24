using Zenject;

namespace Health.presentation.HealthHandler
{
    public class PlayerHealthHandlerSync : HealthHandlerSyncBase
    {
        [Inject] private PlayerHealthHandlerSyncAdapter playerHealthHandlerSyncAdapter;
        protected override string HandlerId => photonView.Owner.UserId;

        protected override bool SetupAdapter(out IHealthHandlerSyncAdapter syncAdapter)
        {
            syncAdapter = playerHealthHandlerSyncAdapter;
            return true;
        }
    }
}