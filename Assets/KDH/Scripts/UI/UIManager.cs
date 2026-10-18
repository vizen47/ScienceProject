using KDH.Scripts.Craft;
using KDH.Scripts.Item;
using KDH.Scripts.Resource;
using TMPro;
using UnityEngine;

namespace KDH.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        
        [field: SerializeField] public GameObject CraftTableUI { get; private set; }
        [field: SerializeField] public GameObject CraftTableBtn { get; private set; }
        [field: SerializeField] public GameObject SellingUI { get; private set; }
        [field: SerializeField] public GameObject SellingBtn { get; private set; }
        [field: SerializeField] public GameObject SuccessUI { get; private set; }
        [field: SerializeField] public GameObject MinigameSurrenderUI { get; private set; }
        [SerializeField] private GameObject canPurchaseUI;
        [SerializeField] private GameObject cannotPurchaseUI;
        [SerializeField] private GameObject canSellingUI;
        [SerializeField] private GameObject cannotSellingUI;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI[] resourceAmountText; // 귀찮아서 배열로
        [SerializeField] private TextMeshProUGUI havingResourceAmountText;
        [field: SerializeField] public TextMeshProUGUI itemCostText, itemDescText;
        
        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            ResourceDataManager.Instance.OnCoinChanged += SetCoinText;
        }

        private void OnDestroy()
        {
            ResourceDataManager.Instance.OnCoinChanged -= SetCoinText;
        }

        public void SetActiveCraftTable()
        {
            CraftTableUI.SetActive(!CraftTableUI.activeSelf);
        }

        public void SetActiveSellingUI()
        {
            SellingUI.SetActive(!SellingUI.activeSelf);
        }
        
        public void CanBuy(ItemSO itemData)
        {
            if (itemData.cost <= ResourceDataManager.Instance.Coin)
            {
                canPurchaseUI.SetActive(true);
            }
            else
            {
                cannotPurchaseUI.SetActive(true);
            }
        }

        public void CanSell(ItemSO itemData)
        {
            if (ResourceDataManager.Instance.ResourceDict.ContainsKey(itemData)  &&
                ResourceDataManager.Instance.ResourceDict[itemData] > 0)
            {
                canSellingUI.SetActive(true);
            }
            else
            {
                cannotSellingUI.SetActive(true);
            }
        }

        public void StartMinigame()
        {
            CraftTableUI.SetActive(false);
            CraftTableBtn.SetActive(false);
            SellingBtn.SetActive(false);
            MinigameSurrenderUI.SetActive(true);
        }
        
        public void EndMinigame()
        {
            CraftTableUI.SetActive(true);
            CraftTableBtn.SetActive(true);
            SellingBtn.SetActive(true);
            SuccessUI.SetActive(true);
            MinigameSurrenderUI.SetActive(false);
        }

        public void SurrenderMinigame()
        {
            CraftTableUI.SetActive(true);
            CraftTableBtn.SetActive(true);
            SellingBtn.SetActive(true);
            MinigameSurrenderUI.SetActive(false);
        }

        private void SetCoinText()
        {
            coinText.SetText($"골드: {ResourceDataManager.Instance.Coin}원");
        }

        public void SetResourceAmountText()
        {
            foreach (var item in resourceAmountText)
            {
                if (item.transform.parent.TryGetComponent(out ItemDataHandler data))
                {
                    if (ResourceDataManager.Instance.ResourceDict.ContainsKey(data.ItemData))
                        item.SetText($"소유하고 있는 물량: {ResourceDataManager.Instance.ResourceDict[data.ItemData]}");
                }
            }
        }

        public void SetTargetResourceAmountText()
        {
            if (ResourceDataManager.Instance.ResourceDict.ContainsKey(CraftManager.Instance.CurrentItem))
                havingResourceAmountText.SetText("현재 가지고 있는 품목의 개수:" + " "+ ResourceDataManager.Instance.ResourceDict[CraftManager.Instance.CurrentItem]);
        }
    }
}