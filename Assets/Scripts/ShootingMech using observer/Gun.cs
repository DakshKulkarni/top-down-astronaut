using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        BulletPool.Instance.GetBullet(firePoint.position, mouseWorldPos);
    }
}
