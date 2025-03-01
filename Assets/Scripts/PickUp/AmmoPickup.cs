using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] private float num_ammo = 5f;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(num_ammo);
    }
}
