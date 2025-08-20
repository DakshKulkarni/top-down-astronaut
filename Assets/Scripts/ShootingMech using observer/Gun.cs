using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public Camera mainCam;
    private BulletFactory bulletFactory;

    void Start()
    {
        BulletPool pool = FindObjectOfType<BulletPool>();
        bulletFactory = new BulletFactory(pool);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            bulletFactory.CreateBullet(firePoint.position, mousePos);
        }
    }
}
