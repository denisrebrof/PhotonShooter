using Health.domain;

namespace Health.data
{
    public class DefaultOneHundredMaxHealthRepository: IMaxHealthRepository
    {
        public int GetMaxHealth() => 100;
    }
}