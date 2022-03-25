using Health.domain;
using Health.domain.repositories;

namespace Health.data
{
    public class DefaultOneHundredMaxHealthRepository: IMaxHealthRepository
    {
        public int GetMaxHealth() => 100;
    }
}