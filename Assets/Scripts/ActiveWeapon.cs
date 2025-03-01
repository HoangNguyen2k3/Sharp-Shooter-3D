using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO starting_weapon;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private GameObject zoomVignette;
    [SerializeField] private TextMeshProUGUI ammo_num;
    [SerializeField] private Camera cam_stack;


    private float current_remain_ammo = 0;
    private WeaponSO current_weapon;
    public Animator anim;
    private StarterAssetsInputs weaponInputs;
    private FirstPersonController firstPersonController;
    private Weapon weapon;
    private float defaultFOV;
    private float current_time = 0f;
    private float default_rotationspeed;
    private void Start()
    {
        current_weapon = starting_weapon;
        AdjustAmmo(starting_weapon.magazineSize);
        defaultFOV = cam.m_Lens.FieldOfView;
        weapon = GetComponentInChildren<Weapon>();
        weaponInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        default_rotationspeed = firstPersonController.GetSpeedRotation();
    }
    private void Update()
    {
        HandleShoot();
        HandleZoom();
    }
    public void AdjustAmmo(float num)
    {
        current_remain_ammo += num;
        if (current_remain_ammo > current_weapon.magazineSize)
        {
            current_remain_ammo = current_weapon.magazineSize;
        }
        ammo_num.text = current_remain_ammo.ToString();
    }

    private void HandleZoom()
    {
        if (!current_weapon.canZoom)
        {
            if (zoomVignette.activeSelf == true || cam.m_Lens.FieldOfView != defaultFOV)
            {
                OutZoomMode();
            }
            return;
        }
        if (weaponInputs.zoom)
        {
            InZoomMode();
        }
        else
        {
            OutZoomMode();
        }
    }

    private void OutZoomMode()
    {
        firstPersonController.ChangeSpeedRotation(default_rotationspeed);
        cam.m_Lens.FieldOfView = defaultFOV;
        cam_stack.fieldOfView = defaultFOV;
        zoomVignette.SetActive(false);
    }

    private void InZoomMode()
    {
        firstPersonController.ChangeSpeedRotation(current_weapon.zoomRotationSpeed);
        cam.m_Lens.FieldOfView = current_weapon.zoomAmount;
        cam_stack.fieldOfView = current_weapon.zoomAmount;
        zoomVignette.SetActive(true);
    }

    private void HandleShoot()
    {
        current_time += Time.deltaTime;
        if (weaponInputs.shoot)
        {
            if (current_time >= current_weapon.firerate && current_remain_ammo > 0)
            {
                anim.Play("Shooting", 0, 0f);
                weapon.Shooting(current_weapon);
                current_time = 0;
                AdjustAmmo(-1);
            }
            if (!current_weapon.isAutomatic)
            {
                weaponInputs.shoot = false;
            }

        }
    }

    public void SwitchWeapon(WeaponSO weapon_type)
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }

        current_weapon = weapon_type;
        Weapon new_weapon = Instantiate(weapon_type.weaponObject, transform).GetComponent<Weapon>();
        weapon = new_weapon;
        current_remain_ammo = 0;
        AdjustAmmo(current_weapon.magazineSize);
    }

}
