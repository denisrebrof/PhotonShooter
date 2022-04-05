using Movement.domain;

namespace Movement.data
{
    public class JumpingStateInMemoryRepository: IJumpingStateRepository
    {
        private bool jump = false;
        
        public bool IsJumping()
        {
            return jump;
        }

        void IJumpingStateRepository.SetJumping(bool jumping)
        {
            jump = jumping;
        }
    }
}