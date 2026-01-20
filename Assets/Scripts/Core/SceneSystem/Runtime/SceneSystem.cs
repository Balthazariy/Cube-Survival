using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace RGD.Core.Scenes
{
    public class SceneSystem : ISceneSystem, IInitializable, IDisposable
    {
        public void Initialize()
        {
        }
        
        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);
        }

        public void LoadSceneAddictive(int id)
        {
        }

        public void Dispose()
        {
        }
    }
}