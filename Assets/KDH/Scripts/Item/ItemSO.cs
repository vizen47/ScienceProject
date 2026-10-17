using UnityEngine;

namespace KDH.Scripts.Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "SO/KDH/ItemData", order = 0)]
    public class ItemSO : ScriptableObject
    {
        public int cost;
        public int sellCost;

        public Sprite itemIcon;
        
        [TextArea] public string desc;

        public GameObject minigamePrefab;
    }
}