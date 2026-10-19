using UnityEngine;

namespace KDH.Scripts.Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "SO/KDH/ItemData", order = 0)]
    public class ItemSO : ScriptableObject
    {
        public float cost;
        public float minCost;
        public float maxCost;
        public float tmpCost;
        public float multiplySellCost;

        public float currentCost;
        
        public Sprite itemIcon;
        [TextArea] public string desc;

        public GameObject minigamePrefab;

        public void Init()
        {
            tmpCost = Mathf.Clamp(cost, minCost, maxCost);
            tmpCost = cost;
        }
        
        public float RandomSellCost()
        {
            int random = Random.Range(0, 2);
            int randomValue = (int)Random.Range(cost * multiplySellCost, cost * multiplySellCost * 1.25f);

            tmpCost += random == 0 ? randomValue : -randomValue;
            tmpCost = Mathf.Clamp(tmpCost, minCost, maxCost);

            currentCost = tmpCost;
            return currentCost;
        }
    }
}