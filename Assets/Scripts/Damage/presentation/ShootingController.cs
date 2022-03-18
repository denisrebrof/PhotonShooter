﻿using UnityEngine;
using UnityEngine.Pool;

namespace Damage.presentation
{
    public class ShootingController : MonoBehaviour
    {
        
        
        private ObjectPool<GameObject> pool = new(
            createFunc: () => new GameObject("PooledObject"),
            actionOnGet: (obj) => obj.SetActive(true),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 10
        );
    }
}