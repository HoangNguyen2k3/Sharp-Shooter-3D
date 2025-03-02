using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform TurretHead;
    [SerializeField] private Transform attackSpawn;
    [SerializeField] private GameObject turretProjectile;
    [SerializeField] private float fireRate;
    [SerializeField] private float damageProjectile;
    [SerializeField] private Transform player;

    private void Start()
    {
        //       player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Attack());
    }
    private void Update()
    {
        if (player != null)
            TurretHead.LookAt(player.position);
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            if (player)
            {
                GameObject projectile = Instantiate(turretProjectile, attackSpawn.position, Quaternion.identity);
                projectile.transform.LookAt(player.position);
                projectile.GetComponent<Projectile>().Init(damageProjectile);
            }

        }

    }
}
