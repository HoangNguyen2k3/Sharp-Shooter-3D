using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObjects/WeaponOS")]
public class WeaponSO : ScriptableObject
{
    public GameObject bloom;
    public float damage = 1f;
    public float firerate = 0.5f;
    public float speed = 0.5f;
}
