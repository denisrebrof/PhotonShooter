﻿using System;
using System.Collections.Generic;
using SpawnPoints.domain.repositories;
using UniRx;
using UnityEngine;
using Utils;
using Utils.Reactive;

namespace SpawnPoints.data
{
    public class SpawnPointCooldownSceneRepository : MonoBehaviour, ISpawnPointCooldownRepository
    {
        private readonly ReactiveDictionary<int, int> pointIdToCooldownMap = new();
        private readonly Dictionary<int, IDisposable> cooldownTimerDisposables = new();

        public IObservable<int> GetCooldownFlow(int pointId) => pointIdToCooldownMap
            .GetItemFlow(pointId)
            .DistinctUntilChanged();

        public int GetCooldown(int pointId) => pointIdToCooldownMap
            .TryGetValue(pointId, out var cooldown)
            ? cooldown
            : 0;

        void ISpawnPointCooldownRepository.SetCooldown(int pointId, int cooldown)
        {
            if (cooldownTimerDisposables.TryGetValue(pointId, out var existingTimerDisposable))
                existingTimerDisposable.Dispose();

            cooldown = Math.Max(0, cooldown);
            pointIdToCooldownMap[pointId] = cooldown;

            if (cooldown == 0) return;

            cooldownTimerDisposables[pointId] = Observable
                .Timer(TimeSpan.FromSeconds(1))
                .Repeat()
                .Where(_ => pointIdToCooldownMap[pointId] > 0)
                .Subscribe(_ => pointIdToCooldownMap[pointId]--)
                .AddTo(this);
        }
    }
}