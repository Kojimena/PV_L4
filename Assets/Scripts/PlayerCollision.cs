using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            GameEventsBehaviour.Instance.RaiseCoinCollected();
            
            // Destruir
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("heart"))
        {
            
            GameEventsBehaviour.Instance.RaiseLifeCollected();
            
            // Destruir
            Destroy(other.gameObject);
            
        }
        
        if (other.CompareTag("key"))
        {
            
            // Destruir
            Destroy(other.gameObject);
            
        }
        
        if (other.CompareTag("door"))
        {
            GameEventsBehaviour.Instance.RaiseDoorEntered();
        }
    }
}
