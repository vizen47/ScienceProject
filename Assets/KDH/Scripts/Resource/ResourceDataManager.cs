using System;
using System.Collections.Generic;
using KDH.Scripts.Item;
using UnityEngine;

namespace KDH.Scripts.Resource
{
    public class ResourceDataManager : MonoBehaviour
    {
        public static ResourceDataManager Instance;

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

        private Dictionary<ItemSO, int> _resourceDict = new();

        private int _currentItemCost;
        
        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Coin = startCoin;
        }
    }
}