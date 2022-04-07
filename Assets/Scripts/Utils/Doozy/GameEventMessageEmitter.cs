using Doozy.Engine;
using UnityEngine;

namespace Utils.Doozy
{
    public class GameEventMessageEmitter : MonoBehaviour
    {
        [SerializeField] private string message;

        public void Emit()
        {
            if(string.IsNullOrEmpty(message))
                return;
        
            GameEventMessage.SendEvent(message);
        }
    }
}
