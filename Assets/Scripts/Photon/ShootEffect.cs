using Photon.Pun;
using UnityEngine;

namespace Photon
{
    public class ShootEffect : MonoBehaviourPun
    {
        [SerializeField] private float maxDist = 10f;
        [SerializeField] private GameObject hitGround;
        [SerializeField] private GameObject smoke;

        public void HandleShoot(Vector3 source, Vector3 pos, HitEffectType type)
        {
            photonView.RPC(nameof(RPC_HandleShoot), RpcTarget.All, source, pos, (int) type);
        }

        [PunRPC]
        private void RPC_HandleShoot(Vector3 source, Vector3 pos, int effectType)
        {
            var type = (HitEffectType) effectType;
            var smokeVector = pos - source;
            if (smokeVector.magnitude > maxDist)
                smokeVector = smokeVector.normalized * maxDist;
            var endSmokePos = source + smokeVector;
            Instantiate(smoke, source, Quaternion.FromToRotation(source, pos))
                .GetComponent<LineRenderer>()
                .SetPositions(new[]
                {
                    source,
                    Vector3.Lerp(source, pos, 0.25f),
                    Vector3.Lerp(source, pos, 0.75f),
                    pos
                });

            if (type != HitEffectType.Ground) return;
            Instantiate(hitGround, pos, Quaternion.identity);
        }

        public enum HitEffectType
        {
            None,
            Player,
            Ground
        }
    }
}