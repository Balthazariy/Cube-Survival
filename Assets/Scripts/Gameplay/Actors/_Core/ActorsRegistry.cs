using System.Collections.Generic;
using UnityEngine;

namespace RGD.Gameplay.Actors._Core
{
    [CreateAssetMenu(fileName = "ActorsRegistry", menuName = "RGD/Gameplay/Actors/ActorsRegistry", order = 0)]
    public class ActorsRegistry : ScriptableObject
    {
        public List<ActorConfig> Actors;
    }
}