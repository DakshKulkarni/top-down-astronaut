using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void FireTowards(Vector3 targetPos)
    {
        targetPos.z = 0;
        Vector3 direction = (targetPos - transform.position).normalized;
        // Set velocity in the dir of the mouse
        rb.velocity = direction * speed;
        // Set rotation to face the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        // Auto-disable after time if needed
        CancelInvoke();
        Invoke(nameof(DisableSelf), 3f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            KillEventManager.Instance.NotifyKill();
            Destroy(other.gameObject);
            DisableSelf();
        }
    }
    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
