using System;
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
        [field: SerializeField] public GameObject SellingBtn { get; private set; }
        [field: SerializeField] public GameObject SuccessUI { get; private set; }
        [field: SerializeField] public GameObject MinigameSurrenderUI { get; private set; }
        [SerializeField] private GameObject canPurchaseUI;
        [SerializeField] private GameObject cannotPurchaseUI;
        [SerializeField] private TextMeshProUGUI coinText;
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
    }
}