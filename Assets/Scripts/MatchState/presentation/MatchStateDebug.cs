﻿using System;
using MatchState.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace MatchState.presentation
{
    public class MatchStateDebug: MonoBehaviour
    {
        [Inject] private IMatchTimerRepository matchTimerRepository;
        [Inject] private IMatchStateRepository matchStateRepository;
        
        private void Start()
        {
            matchTimerRepository.GetMatchTimeSecondsFlow().Subscribe(time => Debug.Log(time.ToString())).AddTo(this);
            matchStateRepository.GetMatchStateFlow().Subscribe(state => Debug.Log("State: " + state)).AddTo(this);
        }
    }
}