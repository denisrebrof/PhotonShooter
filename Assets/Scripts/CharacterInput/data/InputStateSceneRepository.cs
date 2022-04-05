using System;
using CharacterInput.domain;
using CharacterInput.domain.model;
using CharacterInput.domain.repositories;
using UnityEngine;

namespace CharacterInput.data
{
    public class InputStateSceneRepository: MonoBehaviour, IInputStateRepository
    {
        [SerializeField] private InputState state = InputState.Full;

        public void SetInputOn() => state = InputState.Full;
        
        public void SetInputOff() => state = InputState.Disabled;

        public InputState GetInputState() => state;
    }
}