using UnityEngine;

public class BulletFactory
{
    private BulletPool bulletPool;

    public BulletFactory(BulletPool pool)
    {
        bulletPool = pool;
    }

    public GameObject CreateBullet(Vector3 firePosition, Vector3 targetPosition)
    {
        return bulletPool.GetBullet(firePosition, targetPosition);
    }
}
