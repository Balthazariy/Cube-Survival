using System;
using RGD.Core.ObjectsLoading;
using RGD.Gameplay.Actors.Core;
using UnityEngine;
using VContainer.Unity;

namespace RGD.Gameplay.Actors._Core
{
    public class ActorsFactory : IActorsFactory, IInitializable, IDisposable
    {
        private IObjectsLoadingSystem _objectsLoadingSystem;
        
        private ActorsRegistry _actorsRegistry;
        
        public ActorsFactory(IObjectsLoadingSystem objectsLoadingSystem)
        {
            _objectsLoadingSystem = objectsLoadingSystem;
        }

        public void Initialize()
        {
            _actorsRegistry = _objectsLoadingSystem.LoadObject<ActorsRegistry>("ActorsRegistry");
        }

        public void Dispose()
        {
            _objectsLoadingSystem = null;
            _actorsRegistry = null;
        }
    }
}
