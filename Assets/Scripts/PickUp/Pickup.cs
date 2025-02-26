using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float speed_rotate = 100f;

    private string TARGET_PICKUP = "Player";
    private void Update()
    {
        transform.Rotate(Vector3.up * speed_rotate * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TARGET_PICKUP))
        {
            ActiveWeapon activeWeapon = other.gameObject.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(gameObject);
        }
    }
    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
