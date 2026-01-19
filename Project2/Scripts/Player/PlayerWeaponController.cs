using UnityEngine;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour
{
    public PlayerInventory inventory;
    public Camera playerCamera;

    float fireTimer;

    void Update()
    {
        if (inventory.currentWeapon == null) return;

        HandleFire();
        HandleReload();
        HandleWeaponSwitch();
        HandleDrop();
    }

    void HandleFire()
    {
        Weapon weapon = inventory.currentWeapon;

        fireTimer -= Time.deltaTime;

        bool fireInput =
            weapon.data.fireMode == FireMode.Auto
                ? Input.GetMouseButton(0)
                : Input.GetMouseButtonDown(0);

        if (!fireInput || fireTimer > 0f) return;
        if (weapon.CurrentAmmo <= 0) return;

        fireTimer = weapon.data.fireRate;
        weapon.CurrentAmmo--;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, weapon.data.range))
        {
            Debug.Log($"Hit {hit.collider.name}");
        }
    }

    void HandleReload()
    {
        Weapon weapon = inventory.currentWeapon;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weapon.CurrentAmmo == weapon.data.magazineSize) return;
            if (weapon.ReserveAmmo <= 0) return;

            StartCoroutine(ReloadRoutine(weapon));
        }
    }

    IEnumerator ReloadRoutine(Weapon weapon)
    {
        weapon.state = WeaponState.Reloading;
        yield return new WaitForSeconds(weapon.data.reloadTime);

        int needed = weapon.data.magazineSize - weapon.CurrentAmmo;
        int amount = Mathf.Min(needed, weapon.ReserveAmmo);

        weapon.CurrentAmmo += amount;
        weapon.ReserveAmmo -= amount;

        weapon.state = WeaponState.Equipped;
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.primary1)
            inventory.EquipWeapon(inventory.primary1);

        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.primary2)
            inventory.EquipWeapon(inventory.primary2);

        if (Input.GetKeyDown(KeyCode.Alpha3) && inventory.secondary)
            inventory.EquipWeapon(inventory.secondary);
    }

    void HandleDrop()
    {
        if (Input.GetKeyDown(KeyCode.G))
            inventory.DropCurrentWeapon();
    }
}
