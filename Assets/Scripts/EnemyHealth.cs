using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem explosion;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            SelfDestruction();
        }
    }
    public void SelfDestruction()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
