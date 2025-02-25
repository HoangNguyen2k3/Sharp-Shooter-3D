using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO current_weapon;
    [SerializeField] private StarterAssetsInputs weaponInputs;
    public Animator anim;
    [SerializeField] private Weapon weapon;
    private float current_time = 0f;
    private void Start()
    {
        //        weaponInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        current_time += Time.deltaTime;
        if (current_time >= current_weapon.firerate)
        {
            current_time = 0;
            if (weaponInputs.shoot)
            {
                anim.Play("Shooting", 0, 0f);
                weapon.Shooting(current_weapon);
                weaponInputs.shoot = false;
            }
        }

    }
}
