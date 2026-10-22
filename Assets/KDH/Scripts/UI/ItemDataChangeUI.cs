using KDH.Scripts.Craft;
using KDH.Scripts.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KDH.Scripts.UI
{
    public class ItemDataChangeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [field: SerializeField] public ItemSO itemData;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void SetCurrentItem()
        {
            CraftManager.Instance.SetCurrentItem(itemData);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.Instance.itemCostText.SetText($"비용: {(int)(itemData.currentCost * itemData.personnelExpenses)}");
            UIManager.Instance.itemDescText.SetText(itemData.desc);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // CraftManager.Instance.SetCurrentItem(null); // 어짜피 다른 게 Item이 골라질 확률이 없는 거 같음.
            UIManager.Instance.itemCostText.SetText("");
            UIManager.Instance.itemDescText.SetText("");
        }
    }
}