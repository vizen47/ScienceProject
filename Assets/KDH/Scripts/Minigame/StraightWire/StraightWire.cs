using System.Collections.Generic;
using System.Linq;
using KDH.Scripts.UI;
using UnityEngine;
using Random = System.Random;

namespace KDH.Scripts.Minigame.StraightWire
{
    public class StraightWire : MonoBehaviour
    {
        [field: SerializeField] public Vector3 StartPos { get; set; }
        [field: SerializeField] public Vector3 EndPos { get; set; }

        [SerializeField] private LayerMask whatIsBlock;
        [SerializeField] private Transform[] leftSpawnPoints;
        [SerializeField] private Transform[] rightSpawnPoints;
        [SerializeField] private GameObject[] leftBlocks;
        [SerializeField] private GameObject[] rightBlocks;

        [SerializeField] private float yScale = 0.25f;
        [SerializeField] private float xScale = 4f;

        private List<GameObject> _leftList = new();
        private List<GameObject> _rightList = new();
        private Random _random = new();

        private Vector3 _boxCenter;
        private Vector2 _boxSize;
        private float _angle;
        private bool _isGameEnded;

        private void Start()
        {
            int blockCount = Mathf.Min(leftSpawnPoints.Length, rightSpawnPoints.Length, leftBlocks.Length, rightBlocks.Length);

            for (int i = 0; i < blockCount; i++)
            {
                GameObject blockL = Instantiate(leftBlocks[i], transform);
                GameObject blockR = Instantiate(rightBlocks[i], transform);

                _leftList.Add(blockL);
                _rightList.Add(blockR);
            }

            List<Transform> leftList = leftSpawnPoints.Take(blockCount).OrderBy(empty => _random.Next()).ToList();

            for (int i = 0; i < blockCount; i++)
            {
                _leftList[i].transform.position = leftList[i].position;
            }

            List<Transform> rightList = rightSpawnPoints.Take(blockCount).OrderBy(empty => _random.Next()).ToList();

            for (int i = 0; i < blockCount; i++)
            {
                _rightList[i].transform.position = rightList[i].position;
            }
        }
        
        public void CalcDrag(Vector3 start, Vector3 end)
        {
            if (_isGameEnded)
                return;

            Vector2 direction = end - start;
            float distance = direction.magnitude;

            _boxCenter = (start + end) * 0.5f;
            _boxSize = new Vector2(distance, yScale);
            _angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Collider2D[] hits = Physics2D.OverlapBoxAll(_boxCenter, _boxSize, _angle, whatIsBlock);

            List<Block> hitBlocks = new();

            foreach (Collider2D hit in hits)
            {
                Block block = hit.GetComponent<Block>();

                if (block != null && !block.isCleared && !hitBlocks.Contains(block))
                {
                    hitBlocks.Add(block);
                }
            }

            bool sameType = hitBlocks.Count >= 2 && hitBlocks.All(block => block.CurrentType == hitBlocks[0].CurrentType);

            if (sameType)
            {
                foreach (Block block in hitBlocks)
                {
                    if (block.Line != null)
                    {
                        block.Line.transform.position = new Vector3(_boxCenter.x, _boxCenter.y, 1f);
                        block.Line.transform.rotation = Quaternion.Euler(0f, 0f, _angle);
                        block.Line.transform.localScale = new Vector3(distance * xScale, yScale * xScale, 1f);
                    }

                    block.isCleared = true;
                }
            }

            bool clear = _leftList.All(item => item != null && item.TryGetComponent(out Block block) && block.isCleared);

            if (clear)
            {
                _isGameEnded = true;
                UIManager.Instance.SuccessUI.SetActive(true);
            }
        }

        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.yellow;
        //     Gizmos.matrix = Matrix4x4.TRS(_boxCenter, Quaternion.Euler(0f, 0f, _angle), Vector3.one);
        //
        //     Gizmos.DrawWireCube(Vector3.zero, _boxSize);
        // }
    }
}