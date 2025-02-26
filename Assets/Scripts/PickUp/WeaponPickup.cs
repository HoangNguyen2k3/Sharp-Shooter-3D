using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] public WeaponSO current_weapon;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(current_weapon);
    }
}
