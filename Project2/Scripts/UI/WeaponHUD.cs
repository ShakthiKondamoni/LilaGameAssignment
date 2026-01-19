using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    public PlayerInventory inventory;

    [Header("Main Info")]
    public Text weaponNameText;
    public Text ammoText;

    [Header("Slot UI")]
    public Image primary1BG;
    public Image primary2BG;
    public Image secondaryBG;

    public Text primary1Text;
    public Text primary2Text;
    public Text secondaryText;

    Color normalColor = new Color(0.2f, 0.2f, 0.2f, 0.8f);
    Color activeColor = new Color(1f, 0.85f, 0.2f, 1f);

    void Update()
    {
        UpdateWeaponInfo();
        UpdateSlots();
    }

    void UpdateWeaponInfo()
    {
        if (inventory.currentWeapon == null)
        {
            weaponNameText.text = "NO WEAPON";
            ammoText.text = "-- / --";
            return;
        }

        Weapon w = inventory.currentWeapon;
        weaponNameText.text = w.data.weaponName;
        ammoText.text = $"{w.CurrentAmmo} / {w.ReserveAmmo}";
    }

    void UpdateSlots()
    {
        UpdateSlot(primary1Text, primary1BG, inventory.primary1);
        UpdateSlot(primary2Text, primary2BG, inventory.primary2);
        UpdateSlot(secondaryText, secondaryBG, inventory.secondary);
    }

    void UpdateSlot(Text text, Image bg, Weapon weapon)
    {
        if (weapon == null)
        {
            text.text = "EMPTY";
            bg.color = normalColor;
            return;
        }

        text.text = weapon.data.weaponName;

        bg.color = (weapon == inventory.currentWeapon)
            ? activeColor
            : normalColor;
    }
}
