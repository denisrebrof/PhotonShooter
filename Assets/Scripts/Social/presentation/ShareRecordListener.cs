using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Social
{
    public class ShareRecordListener : MonoBehaviour
    {
        [SerializeField] private float delay = 1;
        [SerializeField] private UnityEvent onRecordReached;

        private string prefskey = "ShareInvite";

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(delay);
            onRecordReached.Invoke();
            PlayerPrefs.SetInt(prefskey, 1);
        }

        public void CheckAndShow()
        {
            if (PlayerPrefs.HasKey(prefskey)) return;
            StartCoroutine(Delay());
        }
    }
}