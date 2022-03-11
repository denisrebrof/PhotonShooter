using UnityEngine;
using UnityEngine.Events;

namespace Shooting.presentation
{
    public class ShootingProjectile : MonoBehaviour
    {
        private Transform root;
        [SerializeField] private UnityEvent onAnyCollision = new();
        [SerializeField] private float speed;

        private void Start() => root = GetComponent<Transform>();

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            var ray = new Ray(root.position, root.forward);
            if (!Physics.Raycast(ray, out var hit)) return;
            onAnyCollision.Invoke();
            HandleHit(hit);
        }

        private void HandleHit(RaycastHit hit)
        {
            //do nothing
        }
    }
}