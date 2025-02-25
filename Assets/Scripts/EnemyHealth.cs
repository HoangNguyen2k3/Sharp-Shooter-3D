using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float currentHealth;
    [SerializeField] private float maxHealth;

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
            Destroy(gameObject);
        }
    }
}
