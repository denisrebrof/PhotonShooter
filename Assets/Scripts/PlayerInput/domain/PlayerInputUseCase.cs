using PlayerInput.domain.model;
using PlayerInput.domain.repositories;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using Zenject;

namespace PlayerInput.domain
{
    public class PlayerInputUseCase
    {
        [Inject] private IPlayerInputRepository inputRepository;
        [Inject] private IPlayerStateRepository playerStateRepository;
        [Inject] private PlayerInputSuspendedUseCase inputSuspendedUseCase;

        public float GetAxis(CharacterInputAxis axis) => InputAvailable(axis) ? 0f : inputRepository.GetAxis(axis);

        public bool GetSelection(out int selection)
        {
            var invalidPlayerState = playerStateRepository.GetPlayerState() != PlayerStates.Playing;
            if (!invalidPlayerState)
                return inputRepository.GetSelection(out selection);

            selection = 0;
            return false;
        }

        private bool InputAvailable(CharacterInputAxis axis)
        {
            var invalidPlayerState = playerStateRepository.GetPlayerState() != PlayerStates.Playing;
            var axisSuspended = inputSuspendedUseCase.GetAxisSuspended(axis);
            return invalidPlayerState || axisSuspended;
        }
    }
}