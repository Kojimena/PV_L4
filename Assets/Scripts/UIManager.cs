using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI References")]
    [SerializeField] private TMP_Text coinText;
    
    private int coinCount;

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
            GameEventsBehaviour.Instance.OnCoinCollected += UpdateCoins;
    }

    private void OnDisable()
    {
        if (GameEventsBehaviour.Instance != null)
            GameEventsBehaviour.Instance.OnCoinCollected -= UpdateCoins;
    }

    private void UpdateCoins()
    {
        coinCount++;
        coinText.text = $"Coins: {coinCount}";
    }
}