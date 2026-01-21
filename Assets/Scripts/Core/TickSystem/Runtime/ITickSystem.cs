using System;
using UnityEngine;

namespace RGD.Core.Ticks
{
    public interface ITickSystem
    {
        public void RegisterTick(Action<float> action);
        public void RegisterFixedTick(Action<float> action);
        public void RegisterLateTick(Action<float> action);
        
        public void UnregisterTick(Action<float> action);
        public void UnregisterFixedTick(Action<float> action);
        public void UnregisterLateTick(Action<float> action);
    }
}
