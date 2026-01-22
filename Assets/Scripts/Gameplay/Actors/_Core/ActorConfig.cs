using UnityEngine;

namespace RGD.Gameplay.Actors._Core
{
    [CreateAssetMenu(fileName = "ActorConfig", menuName = "RGD/Gameplay/Actors/ActorConfig", order = 1)]
    public class ActorConfig : ScriptableObject
    {
        public string ActorID;
        public string ActorName;
        public GameObject ActorPrefab;
    }
}