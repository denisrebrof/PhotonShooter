namespace Shooting.presentation.SyncHandler
{
    public class PlayerShootingHandlerSync: ShootingHandlerSyncBase
    {
        protected override string HandlerId => photonView.Controller.UserId;
    }
}