using System.Collections.Generic;
using UnityEngine;
public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject bulletPrefab;
    public int poolSize = 20;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
    public GameObject GetBullet(Vector3 firePosition, Vector3 targetPosition)
    {
        if (bulletPool.Count == 0) return null;
        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.position = firePosition;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().FireTowards(targetPosition);
        bulletPool.Enqueue(bullet);
        return bullet;
    }
}
