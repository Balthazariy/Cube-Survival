using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RGD.Core.Ticks
{
    public class TickSystem : ITickSystem, IInitializable, IDisposable, ITickable, IFixedTickable, ILateTickable
    {
        private HashSet<Action<float>> _tickList;
        private HashSet<Action<float>> _fixedTickList;
        private HashSet<Action<float>> _lateTickList;

        public void Initialize()
        {
            _tickList = new HashSet<Action<float>>();
            _fixedTickList = new HashSet<Action<float>>();
            _lateTickList = new HashSet<Action<float>>();
        }

        public void Dispose()
        {
            _tickList.Clear();
            _fixedTickList.Clear();
            _lateTickList.Clear();
        }

        public void RegisterTick(Action<float> action)
        {
            if (!_tickList.Add(action))
            {
                throw new Exception($"TickSystem: Tick {action.Method.Name} is already registered");
            }
        }

        public void RegisterFixedTick(Action<float> action)
        {
            if (!_fixedTickList.Add(action))
            {
                throw new Exception($"TickSystem: FixedTick {action.Method.Name} is already registered");
            }
        }

        public void RegisterLateTick(Action<float> action)
        {
            if (!_lateTickList.Add(action))
            {
                throw new Exception($"TickSystem: LateTick {action.Method.Name} is already registered");
            }
        }

        public void UnregisterTick(Action<float> action)
        {
            _tickList.Remove(action);
        }

        public void UnregisterFixedTick(Action<float> action)
        {
            _fixedTickList.Remove(action);
        }

        public void UnregisterLateTick(Action<float> action)
        {
            _lateTickList.Remove(action);
        }

        public void Tick()
        {
            var deltaTime = Time.deltaTime;
            foreach (var tick in _tickList)
            {
                tick.Invoke(deltaTime);
            }
        }

        public void FixedTick()
        {
            var deltaTime = Time.fixedDeltaTime;
            foreach (var tick in _fixedTickList)
            {
                tick.Invoke(deltaTime);
            }
        }

        public void LateTick()
        {
            var deltaTime = Time.deltaTime;
            foreach (var tick in _lateTickList)
            {
                tick.Invoke(deltaTime);
            }
        }
    }
}