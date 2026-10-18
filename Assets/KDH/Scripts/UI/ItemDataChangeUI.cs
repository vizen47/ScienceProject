using KDH.Scripts.Craft;
using KDH.Scripts.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KDH.Scripts.UI
{
    public class ItemDataChangeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [field: SerializeField] public ItemSO itemData;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            CraftManager.Instance.SetCurrentItem(itemData);
            UIManager.Instance.itemCostText.SetText($"가격: {itemData.cost}");
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