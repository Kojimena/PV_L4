using UnityEngine;
using System;
using UnityEngine.Events;

[DefaultExecutionOrder(-1000)]

public class GameEventsBehaviour : MonoBehaviour
{
    
    public static GameEventsBehaviour Instance;
    public event Action OnCoinCollected; // Evento para cuando se recoge una moneda
    public event Action OnLifeCollected; // Evento para cuando se recoge una vida
    
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
    
    public void RaiseCoinCollected()
    {
        OnCoinCollected?.Invoke();
    }
    
    public void RaiseLifeCollected()
    {
        OnLifeCollected?.Invoke();
    }
    
    
}
