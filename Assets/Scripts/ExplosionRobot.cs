using UnityEngine;

public class ExplosionRobot : MonoBehaviour
{
    [SerializeField] private float rangeExplosion = 1.5f;
    [SerializeField] private float damage = 1f;

    private void Start()
    {
        Explosion();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, rangeExplosion);
    }
    public void Explosion()
    {
        Collider[] hitbox = Physics.OverlapSphere(transform.position, rangeExplosion);
        foreach (var item in hitbox)
        {
            PlayerHealth health = item.GetComponent<PlayerHealth>();
            if (!health) continue;
            health.TakeDamage(damage);
            break;
        }
    }


}
