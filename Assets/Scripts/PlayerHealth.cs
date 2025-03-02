using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float maxHealth;
    [SerializeField] private CinemachineVirtualCamera deathSceneCam;
    [SerializeField] private Transform weapon_camera;

    [SerializeField] private Image[] health_bar;
    [SerializeField] private GameObject gameOverScreen;

    private float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
        ChangeHealthBar();
    }
    private void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        ChangeHealthBar();
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        weapon_camera.parent = null;
        deathSceneCam.Priority = 20;
        gameOverScreen.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(gameObject);
    }

    public void ChangeHealthBar()
    {
        for (int i = 0; i < health_bar.Length; i++)
        {
            if (i < currentHealth)
            {
                health_bar[i].gameObject.SetActive(true);
            }
            else
            {
                health_bar[i].gameObject.SetActive(false);
            }
        }
    }
}
