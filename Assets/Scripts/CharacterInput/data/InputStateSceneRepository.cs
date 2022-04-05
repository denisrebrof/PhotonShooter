using System;
using CharacterInput.domain;
using CharacterInput.domain.model;
using CharacterInput.domain.repositories;
using UnityEngine;

namespace CharacterInput.data
{
    public class InputStateSceneRepository: MonoBehaviour, IInputStateRepository
    {
        [SerializeField] private CharacterInputState state = CharacterInputState.Full;

        public void SetInputOn() => state = CharacterInputState.Full;
        
        public void SetInputOff() => state = CharacterInputState.Disabled;

        public CharacterInputState GetInputState() => state;
    }
}