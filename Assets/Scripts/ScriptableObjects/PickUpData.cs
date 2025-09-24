using UnityEngine;

[CreateAssetMenu(fileName = "PickUpData", menuName = "Items/PickUp")]
public class PickUpData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public AudioClip pickUpSound;
    
    [Tooltip("Prefab")]
    public GameObject worldPrefab;

    [Header("Opciones")]
    public bool goesToInventory = true;
}