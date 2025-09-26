using System;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    [SerializeField] private HealthItemData healthData;
   
   
   
    private void OnEnable()
    {
        GameEventsBehaviour.Instance.OnLifeCollected += OnHeartCollectedFunction;
    }

    private void OnDisable()
    {
        GameEventsBehaviour.Instance.OnLifeCollected -= OnHeartCollectedFunction;
    }
   
    private void OnHeartCollectedFunction()
    {

        if (healthData.pickUpSound != null)
        {
            AudioManager.instance.PlayAudioClip(healthData.pickUpSound);
        }
        
    }
   
}