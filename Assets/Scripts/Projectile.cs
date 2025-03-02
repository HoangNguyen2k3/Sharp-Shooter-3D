using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private ParticleSystem bloom;
    private float damage;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.linearVelocity = transform.forward * speed;
    }
    public void Init(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Instantiate(bloom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
