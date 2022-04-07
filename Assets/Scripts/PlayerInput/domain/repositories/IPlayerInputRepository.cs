using PlayerInput.domain.model;

namespace PlayerInput.domain.repositories
{
    internal interface IPlayerInputRepository
    {
        public bool GetSelection(out int selection);
        public float GetAxis(CharacterInputAxis axis);
    }
}