using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem explosion;
    GameManager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesText(1f);
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
        gameManager.AdjustEnemiesText(-1f);
        Destroy(gameObject);
    }
}
