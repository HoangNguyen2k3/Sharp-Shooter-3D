using Cinemachine;
using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] public WeaponSO current_weapon;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private GameObject zoomVignette;

    public Animator anim;
    private StarterAssetsInputs weaponInputs;
    private FirstPersonController firstPersonController;
    private Weapon weapon;
    private float defaultFOV;
    private float current_time = 0f;
    private float default_rotationspeed;
    private void Start()
    {
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
        zoomVignette.SetActive(false);
    }

    private void InZoomMode()
    {
        firstPersonController.ChangeSpeedRotation(current_weapon.zoomRotationSpeed);
        cam.m_Lens.FieldOfView = current_weapon.zoomAmount;
        zoomVignette.SetActive(true);
    }

    private void HandleShoot()
    {
        current_time += Time.deltaTime;
        if (weaponInputs.shoot)
        {
            if (current_time >= current_weapon.firerate)
            {
                anim.Play("Shooting", 0, 0f);
                weapon.Shooting(current_weapon);
                current_time = 0;
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
    }

}
