using UnityEngine;
using System;

public class Zombie : MonoBehaviour
{
    public static event Action<int> OnZombieKilled;
    private static int killCount = 0;

    public void Die()
    {
        killCount++;
        OnZombieKilled?.Invoke(killCount);

        Destroy(gameObject);
    }
}
