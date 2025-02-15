using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform _holdPosition;
    [SerializeField] private Button _dropButton;
    [SerializeField] private Transform _carStoragePosition; 
    [SerializeField] private Button _placeInCarButton; 

    private GameObject _heldItem;
    private float _lastTapTime;
    private const float _doubleTapThreshold = 0.3f; 

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - _lastTapTime < _doubleTapThreshold)
                {
                    DropItem();
                }
                else
                {
                    TryPickUpItem();
                }

                _lastTapTime = Time.time;
            }
        }
    }

    void TryPickUpItem()
    {
        if (_heldItem == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f))
            {
                if (hit.collider.CompareTag("Pickupable"))
                {
                    PickUpItem(hit.collider.gameObject);
                }
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        _heldItem = item;
        _heldItem.transform.SetParent(_holdPosition);
        _heldItem.transform.localPosition = Vector3.zero;
        _heldItem.transform.localRotation = Quaternion.identity;

        if (_heldItem.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.isKinematic = true;
        }

        _dropButton.gameObject.SetActive(true);
        _dropButton.onClick.AddListener(DropItem);
        _placeInCarButton.gameObject.SetActive(true);
        _placeInCarButton.onClick.AddListener(PlaceItemInCar);
    }

    void DropItem()
    {
        if (_heldItem != null)
        {
            _heldItem.transform.SetParent(null);

            if (_heldItem.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 5f, ForceMode.Impulse);
            }

            _heldItem = null;
            _dropButton.gameObject.SetActive(false);
            _placeInCarButton.gameObject.SetActive(false);
        }
    }

    public void PlaceItemInCar()
    {
        if (_heldItem != null)
        {
            _heldItem.transform.SetParent(_carStoragePosition);
            _heldItem.transform.localPosition = Vector3.zero;
            _heldItem.transform.localRotation = Quaternion.identity;

            if (_heldItem.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.isKinematic = true;
            }

            _heldItem = null;
            _dropButton.gameObject.SetActive(false);
            _placeInCarButton.gameObject.SetActive(false);
        }
    }
}
