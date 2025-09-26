using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI References")]
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text livesText;
    
    
    [Header("Inventory UI")]
    [SerializeField] private Transform inventoryContent; 
    [SerializeField] private GameObject inventoryItemPrefab; 

    
    private int coinCount;
    private List<PickUpData> inventory = new List<PickUpData>();



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        if (GameEventsBehaviour.Instance != null)
        {
            GameEventsBehaviour.Instance.OnCoinCollected += UpdateCoins;
            GameEventsBehaviour.Instance.OnLivesChanged += UpdateLivesUI;
            GameEventsBehaviour.Instance.OnItemInventoryCollected += AddToInventory;
        }


    }

    private void OnDisable()
    {
        if (GameEventsBehaviour.Instance != null)
        {
            GameEventsBehaviour.Instance.OnCoinCollected -= UpdateCoins;
            GameEventsBehaviour.Instance.OnLivesChanged -= UpdateLivesUI;
            GameEventsBehaviour.Instance.OnItemInventoryCollected -= AddToInventory;
        }
    }
    

    private void UpdateCoins()
    {
        coinCount++;
        coinText.text = $"Coins: {coinCount}";
    }
    
    private void UpdateLivesUI(int currentLives, int maxLives)
    {
        
        livesText.text = $"Lives: {currentLives}/{maxLives}";
    }
    
    private void AddToInventory(PickUpData data)
    {
        if (data == null) return;
        inventory.Add(data);


        GameObject itemGO = Instantiate(inventoryItemPrefab, inventoryContent);
        
        Image icon = itemGO.GetComponentInChildren<Image>();
        TMP_Text nameText = itemGO.GetComponentInChildren<TMP_Text>();

        if (icon) icon.sprite = data.icon;
        if (nameText) nameText.text = data.displayName;
    }

}