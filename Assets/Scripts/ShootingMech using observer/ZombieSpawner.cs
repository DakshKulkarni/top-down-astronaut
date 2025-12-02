using UnityEngine;
public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform player;
    public float spawnInterval = 3f;
    public Transform[] spawnPoints;
    private float timer = 0f;
    private ZombieFactory zombieFactory;
    void Start()
    {
        zombieFactory = new ZombieFactory(zombiePrefab);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnZombie();
        }
    }
    void SpawnZombie()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        zombieFactory.CreateZombie(spawnPoint.position, player);
    }
}
