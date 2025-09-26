using System;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
   [SerializeField] private ValuedItemData coinData;
   
   
   
   private void OnEnable()
   {
      GameEventsBehaviour.Instance.OnCoinCollected += OnCoinCollectedFunction;
   }

   private void OnDisable()
   {
      GameEventsBehaviour.Instance.OnCoinCollected -= OnCoinCollectedFunction;
   }
   
   private void OnCoinCollectedFunction()
   {
      if (coinData.pickUpSound != null)
      {
         AudioManager.instance.PlayAudioClip(coinData.pickUpSound);
      }
   }
   
}
