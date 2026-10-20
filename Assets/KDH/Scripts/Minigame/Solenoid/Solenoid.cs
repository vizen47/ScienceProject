using UnityEngine;

namespace KDH.Scripts.Minigame.Solenoid
{
    public class Solenoid : MonoBehaviour
    {
        [field: SerializeField] public PointEffector2D PointEffector { get; private set; }
        
        public bool CanElectronic { get; set; }

        private void Awake()
        {
            CanElectronic = false;
        }
    }
}
