using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float time_spawn = 5f;

    private bool isSpawning = false;
    private PlayerHealth player;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
    }
    private void Update()
    {
        if (player != null)
        {
            if (!isSpawning)
            {
                StartCoroutine(SpawnEnemies());
            }
        }
    }
    private IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(time_spawn);
        isSpawning = false;
    }
}
