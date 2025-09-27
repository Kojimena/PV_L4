using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 10;
    private int currentLives;
    [SerializeField] private float fallThreshold = -10f;
    
    private void OnEnable()
    {
        if (GameEventsBehaviour.Instance != null)
            GameEventsBehaviour.Instance.OnLifeCollected += OnLifePickup;
    }

    private void OnDisable()
    {
        if (GameEventsBehaviour.Instance != null)
            GameEventsBehaviour.Instance.OnLifeCollected -= OnLifePickup;
    }
    
    void Start()
    {
        currentLives = maxLives;
        GameEventsBehaviour.Instance.RaiseLivesChanged(currentLives, maxLives);

    }
    
    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Die();
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (UIManager.Instance != null &&
                UIManager.Instance.TryConsumeItem("Aid kit", out int healValue))
            {
                Debug.Log(" para curar " + healValue + " vidas.");
                Heal(healValue);
            }
        }

    }
    
    public void Heal(int amount)
    {
        Debug.Log("Curando " + amount + " vidas.");
        if (amount <= 0) return;
        currentLives = Mathf.Clamp(currentLives + amount, 0, maxLives);
        GameEventsBehaviour.Instance.RaiseLivesChanged(currentLives, maxLives);
    }

    

    public void TakeDamage(int amount)
    {
        currentLives = Mathf.Clamp(currentLives - amount, 0, maxLives);
        GameEventsBehaviour.Instance.RaiseLivesChanged(currentLives, maxLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }
    
    private void OnLifePickup()
    {
        currentLives = Mathf.Clamp(currentLives + 1, 0, maxLives);
        GameEventsBehaviour.Instance.RaiseLivesChanged(currentLives, maxLives);
    }
    

    private void Die()
    {
        Debug.Log("¡Jugador muerto!");
        gameObject.SetActive(false); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("LostMenu");
    }
}