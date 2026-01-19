using UnityEngine;

public enum WeaponType
{
    Primary,
    Secondary
}

public enum FireMode
{
    Auto,
    SemiAuto
}

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponType weaponType;

    public int magazineSize;
    public int maxReserveAmmo;

    public FireMode fireMode;
    public float fireRate;
    public float damage;
    public float range;

    [Header ("Reload")]
    public float reloadTime;
}
