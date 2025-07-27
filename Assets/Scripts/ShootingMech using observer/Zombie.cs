using UnityEngine;

public class Zombie : MonoBehaviour
{
    public void Die()
    {
        KillEventManager.Instance?.NotifyKill();
        Destroy(gameObject);
    }
}
