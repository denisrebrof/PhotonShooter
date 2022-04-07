using PlayerInput.domain.model;
using PlayerInput.domain.repositories;
using UnityEngine;

namespace PlayerInput.data
{
    public class InputStateSceneRepository: MonoBehaviour, IInputStateRepository
    {
        [SerializeField] private CharacterInputState state = CharacterInputState.Full;

        public void SetInputOn() => state = CharacterInputState.Full;
        
        public void SetInputOff() => state = CharacterInputState.Disabled;

        public CharacterInputState GetInputState() => state;
    }
}