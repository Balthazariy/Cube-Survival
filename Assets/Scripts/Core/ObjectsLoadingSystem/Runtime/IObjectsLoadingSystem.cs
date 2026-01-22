using UnityEngine;

namespace RGD.Core.ObjectsLoading
{
    public interface IObjectsLoadingSystem
    {
        public T? LoadObject<T>(string address, bool autoRelease = false) where T : Object;
    }
}
