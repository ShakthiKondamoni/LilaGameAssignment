using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform weaponHand;

    public Weapon primary1;
    public Weapon primary2;
    public Weapon secondary;

    public Weapon currentWeapon;

    public void PickupWeapon(Weapon weapon)
    {
        if (weapon.data.weaponType == WeaponType.Primary)
        {
            if (primary1 == null) primary1 = weapon;
            else if (primary2 == null) primary2 = weapon;
            else return;
        }
        else
        {
            if (secondary == null) secondary = weapon;
            else return;
        }

        weapon.gameObject.SetActive(false);
        EquipWeapon(weapon);
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);

        currentWeapon = weapon;
        weapon.gameObject.SetActive(true);
        weapon.SetEquipped(weaponHand);
    }

    public void DropCurrentWeapon()
{
    if (currentWeapon == null) return;

    Weapon dropped = currentWeapon;

    if (dropped == primary1) primary1 = null;
    else if (dropped == primary2) primary2 = null;
    else if (dropped == secondary) secondary = null;

    currentWeapon = null;

    dropped.SetDroppedState();
    dropped.transform.position =
        transform.position + transform.forward * 500f;


    if (primary1 != null) EquipWeapon(primary1);
    else if (primary2 != null) EquipWeapon(primary2);
    else if (secondary != null) EquipWeapon(secondary);
}

}
