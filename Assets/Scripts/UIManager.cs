using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI References")]
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text livesText;

    
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
        {
            GameEventsBehaviour.Instance.OnCoinCollected += UpdateCoins;
            GameEventsBehaviour.Instance.OnLivesChanged += UpdateLivesUI;
        }


    }

    private void OnDisable()
    {
        if (GameEventsBehaviour.Instance != null)
        {
            GameEventsBehaviour.Instance.OnCoinCollected -= UpdateCoins;
            GameEventsBehaviour.Instance.OnLivesChanged -= UpdateLivesUI;
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
}