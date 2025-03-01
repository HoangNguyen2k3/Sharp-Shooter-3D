using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObjects/WeaponOS")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponObject;
    public GameObject bloom;
    public float damage = 1f;
    public float firerate = 0.5f;
    public bool isAutomatic = false;
    public float magazineSize = 10f;
    [Header("Zoom Feature")]
    public bool canZoom = false;
    public float zoomAmount = 10f;
    public float zoomRotationSpeed = 0.3f;

}
