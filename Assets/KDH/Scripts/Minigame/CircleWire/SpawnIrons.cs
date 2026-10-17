using UnityEngine;

namespace KDH.Scripts.Minigame.CircleWire
{
    public class SpawnIrons : MonoBehaviour
    {
        [SerializeField] private GameObject[] irons;
        private Collider2D _spawnColl;

        private void Awake()
        {
            _spawnColl = GetComponent<Collider2D>();
        }

        private void Start()
        {
            foreach (var iron in irons)
            {
                Bounds bounds = _spawnColl.bounds;

                float randX = Random.Range(bounds.min.x, bounds.max.x);
                float randY = Random.Range(bounds.min.y, bounds.max.y);

                iron.transform.position = new Vector3(randX, randY, 0);
            }
        }
    }
}
