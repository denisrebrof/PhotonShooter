using System.Collections.Generic;
using PlayerInput.domain.model;
using PlayerInput.domain.model.InputMask;
using PlayerInput.domain.repositories;

namespace PlayerInput.data
{
    public class DefaultInputMaskRepository: IInputMaskRepository
    {
        private Dictionary<CharacterInputState, IInputMask> masksMap = new()
        {
            { CharacterInputState.Disabled, new InclusiveInputMask() },
            { CharacterInputState.Full, new ExclusiveInputMask() },
        };

        public IInputMask GetInputMask(CharacterInputState state)
        {
            return masksMap[state];
        }
    }
}