using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WeaponPickup : MonoBehaviour
{
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();

        SphereCollider col = GetComponent<SphereCollider>();
        col.isTrigger = true;
        col.radius = 3f;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerC player = other.GetComponent<PlayerC>();
        if (player == null) return;

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        inventory.PickupWeapon(weapon);
    }
}
