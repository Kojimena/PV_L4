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
      Debug.Log($"Moneda recogida: {coinData.displayName} con valor {coinData.value}");
   }
   
}
