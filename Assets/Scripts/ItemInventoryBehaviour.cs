using UnityEngine;

public class ItemInventoryBehaviour : MonoBehaviour
{
    [SerializeField] private PickUpData pickUpData;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (pickUpData.goesToInventory)
        {
            GameEventsBehaviour.Instance.RaiseItemInventoryCollected( pickUpData ); 
        }

        if (pickUpData.pickUpSound != null)
            AudioManager.instance.PlayAudioClip(pickUpData.pickUpSound);

        Destroy(gameObject);
    }
}