using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Utils.Photon
{
    public static class PhotonStreamExtensions
    {
        public static void WriteDictionary<TK, TV>(this PhotonStream stream, IDictionary<TK, TV> dictionary)
        {
            var pairsCount = dictionary.Count;
            stream.SendNext(pairsCount);
            foreach (var (key, value) in dictionary)
            {
                stream.SendNext(key);
                stream.SendNext(value);
            }
        }

        public static bool ReceiveDictionary<TK, TV>(
            this PhotonStream stream,
            Action<TK, TV> onReceivePair
        )
        {
            try
            {
                var pairsCount = (int) stream.ReceiveNext();
                while (pairsCount-- > 0)
                {
                    var nextKey = (TK) stream.ReceiveNext();
                    var nextValue = (TV) stream.ReceiveNext();
                    onReceivePair(nextKey, nextValue);
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
        }
    }
}