using UnityEngine;

public class CarStorage : MonoBehaviour
{
    [SerializeField] private Transform _carStoragePosition; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable") && other.TryGetComponent<ItemPickup>(out ItemPickup itemPickup))
        {
            PlaceItemInCar(other.gameObject);
        }
    }

    
    void PlaceItemInCar(GameObject item)
    {
        item.transform.SetParent(_carStoragePosition); 
        item.transform.localPosition = Vector3.zero; 
        item.transform.localRotation = Quaternion.identity; 

        if (item.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.isKinematic = true;
        }

    }
}
