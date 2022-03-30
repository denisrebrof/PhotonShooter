namespace Shooting.presentation.SyncHandler
{
    public class PlayerShootingSyncHandler: ShootingSyncHandler
    {
        protected override string HandlerId => photonView.Controller.UserId;
    }
}