using System.Collections.Generic;
using CharacterInput.domain;
using CharacterInput.domain.model;
using CharacterInput.domain.repositories;

namespace CharacterInput.data
{
    public class DefaultInputMaskRepository: IInputMaskRepository
    {
        private Dictionary<InputState, IInputMask> masksMap = new()
        {
            { InputState.Disabled, new InclusiveInputMask() },
            { InputState.Full, new ExclusiveInputMask() },
        };

        public IInputMask GetInputMask(InputState state)
        {
            return masksMap[state];
        }
    }
}