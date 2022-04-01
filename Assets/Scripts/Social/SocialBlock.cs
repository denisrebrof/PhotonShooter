using UnityEngine;

namespace Social
{
    public class SocialBlock : MonoBehaviour
    {
        void Start()
        {
#if VK_SDK
        return;
#else
            DestroyImmediate(gameObject);
#endif
        }
    }
}