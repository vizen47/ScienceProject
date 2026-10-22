using System;
using System.Collections.Generic;
using KDH.Scripts.Craft;
using KDH.Scripts.Item;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Resource
{
    public class ResourceDataManager : MonoBehaviour
    {
        public static ResourceDataManager Instance;

        public ItemSO CurrentItemData { get; set; }
        
        [SerializeField] private int startCoin = 500;
        
        public Action OnCoinChanged;
        
        private int _coin;

        public int Coin
        {
            get => _coin;
            set
            {
                if (value >= 0)
                {
                    _coin = value;
                }
            }
        }

        public readonly Dictionary<ItemSO, int> ResourceDict = new();

        private readonly int _currentItemCost;
        
        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Coin = startCoin;
            InitSellCost();
        }

        public void GetResource()
        {
            if (!ResourceDict.TryAdd(CraftManager.Instance.CurrentItem, CraftManager.Instance.MadeItemAmount))
            {
                ResourceDict[CraftManager.Instance.CurrentItem] += CraftManager.Instance.MadeItemAmount;
            }
        }

        public void UseResourceForCoin()
        {
            if (!ResourceDict.TryAdd(CurrentItemData, UIManager.Instance.SellInputTextBox.GetAmount()))
            {
                if (UIManager.Instance.SellInputTextBox.InputField.text == null) return;
                
                int value = Mathf.Min(ResourceDict[CurrentItemData], UIManager.Instance.SellInputTextBox.GetAmount());
                ResourceDict[CurrentItemData] -= value;

                Coin += (int)CurrentItemData.tmpCost * value;
            }
            
            OnCoinChanged?.Invoke();
        }
        
        void InitSellCost()
        {
            foreach (var sellCost in UIManager.Instance.SellCostAmountText)
            {
                if (sellCost.transform.parent.TryGetComponent(out ItemDataHandler data))
                    data.ItemData.Init();
            }
        }
    }
}