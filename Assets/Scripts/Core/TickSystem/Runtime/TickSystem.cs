using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RGD.Core.Ticks
{
    public class TickSystem : ITickSystem, IInitializable, IDisposable
    {
        private Dictionary<Type, Action<float>> _tickList;
        private Dictionary<Type, Action<float>> _fixedTickList;
        private Dictionary<Type, Action<float>> _lateTickList;

        public void Initialize()
        {
            _tickList = new Dictionary<Type, Action<float>>();
            _fixedTickList = new Dictionary<Type, Action<float>>();
            _lateTickList = new Dictionary<Type, Action<float>>();
        }

        public void Dispose()
        {
            _tickList.Clear();
            _fixedTickList.Clear();
            _lateTickList.Clear();
        }

        public void RegisterTick(Action<float> action)
        {
            if (_tickList.ContainsKey(action.GetType()))
            {
                throw new Exception($"UISystem: Tick {action.GetType()} is already registered");
            }

            _tickList.Add(action.GetType(), action);
        }

        public void RegisterFixedTick(Action<float> action)
        {
            if (_fixedTickList.ContainsKey(action.GetType()))
            {
                throw new Exception($"UISystem: FixedTick {action.GetType()} is already registered");
            }

            _fixedTickList.Add(action.GetType(), action);
        }

        public void RegisterLateTick(Action<float> action)
        {
            if (_lateTickList.ContainsKey(action.GetType()))
            {
                throw new Exception($"UISystem: LateTick {action.GetType()} is already registered");
            }

            _lateTickList.Add(action.GetType(), action);
        }

        public void UnregisterTick(Action<float> action)
        {
            _tickList.Remove(action.GetType());
        }

        public void UnregisterFixedTick(Action<float> action)
        {
            _fixedTickList.Remove(action.GetType());
        }

        public void UnregisterLateTick(Action<float> action)
        {
            _lateTickList.Remove(action.GetType());
        }

        public void Tick(float deltaTime)
        {
            foreach (var tick in _tickList.Values)
            {
                tick.Invoke(deltaTime);
            }
        }

        public void FixedTick(float deltaTime)
        {
            foreach (var tick in _fixedTickList.Values)
            {
                tick.Invoke(deltaTime);
            }
        }

        public void LateTick(float deltaTime)
        {
            foreach (var tick in _lateTickList.Values)
            {
                tick.Invoke(deltaTime);
            }
        }
    }
}