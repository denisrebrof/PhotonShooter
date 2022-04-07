namespace SpawnPoints.domain.model
{
    public struct ApplyCooldownEvent
    {
        
        public int PointId;
        public int Cooldown;

        public ApplyCooldownEvent(int pointId, int cooldown)
        {
            PointId = pointId;
            Cooldown = cooldown;
        }
    }
}