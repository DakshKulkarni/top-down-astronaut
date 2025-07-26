using System;
using UnityEngine;

public class KillEventManager : MonoBehaviour
{
    public static KillEventManager Instance { get; private set; }

    public event Action OnKill;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NotifyKill()
    {
        OnKill?.Invoke();
    }
}
