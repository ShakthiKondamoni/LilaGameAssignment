using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public WeaponState state;

    public int CurrentAmmo;
    public int ReserveAmmo;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (data == null)
        {
            Debug.LogError($"WeaponData missing on {gameObject.name}", this);
            return;
        }

        CurrentAmmo = data.magazineSize;
        ReserveAmmo = data.maxReserveAmmo;

        SetDroppedState();
    }

    public void SetEquipped(Transform hand)
    {
        state = WeaponState.Equipped;
        rb.isKinematic = true;
        rb.useGravity = false;

        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void SetDroppedState()
    {
        state = WeaponState.Dropped;
        transform.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
