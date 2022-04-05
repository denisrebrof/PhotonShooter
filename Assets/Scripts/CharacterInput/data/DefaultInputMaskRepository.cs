using System.Collections.Generic;
using CharacterInput.domain;
using CharacterInput.domain.model;
using CharacterInput.domain.repositories;

namespace CharacterInput.data
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