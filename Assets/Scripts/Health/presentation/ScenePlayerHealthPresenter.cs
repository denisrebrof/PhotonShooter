using Health.domain.repositories;
using UnityEngine;
using Zenject;

namespace Health.presentation
{
    public class ScenePlayerHealthPresenter : MonoBehaviour
    {
        [Inject] private IMaxHealthRepository maxHealthRepository;
        [SerializeField] private Transform target;

        public void SetHealth(int health)
        {
            var max = maxHealthRepository.GetMaxHealth();
            ApplyHealth(health, max);
        }

        private void ApplyHealth(int health, int maxHealth)
        {
            var relative = ((float)health) / maxHealth;
            target.localScale = new Vector3(relative, 1, 1);
        }
    }
}