using UnityEngine;

public class ZombieFactory
{
    private GameObject zombiePrefab;

    public ZombieFactory(GameObject prefab)
    {
        zombiePrefab = prefab;
    }

    public GameObject CreateZombie(Vector3 position, Transform playerTarget)
    {
        GameObject zombieGO = GameObject.Instantiate(zombiePrefab, position, Quaternion.identity);

        if (zombieGO.TryGetComponent<IZombie>(out IZombie zombie))
        {
            zombie.Initialize(playerTarget);
        }

        return zombieGO;
    }
}
