namespace Movement.domain.model
{
    public struct MovementState
    {
        public int XAxis;
        public int YAxis;
        public bool Jumping;

        public MovementState(int xAxis, int yAxis, bool jumping)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            Jumping = jumping;
        }
    }
}