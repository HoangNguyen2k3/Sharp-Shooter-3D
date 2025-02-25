using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem shoot;
    private void Start()
    {
    }
    private void Update()
    {
    }
    public void Shooting(WeaponSO current_weapon)
    {
        RaycastHit hit;
        var ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        shoot.Play();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Instantiate(current_weapon.bloom, hit.point, Quaternion.identity);
            if (hit.collider.GetComponent<EnemyHealth>() != null)
            {
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(current_weapon.damage);
            }
        }
    }
}
