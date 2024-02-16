using UnityEngine;
//work in progress, not in use in game
public class StationaryEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;
    public float detectionRange = 10f;
    public int damagePerBullet = 10;
    public LayerMask obstacleLayer;

    private Transform player;
    private float nextFireTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time + 1f / fireRate;
    }

    void Update()
    {
        if (player == null)
            return;

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            RaycastHit hit;
            Vector3 direction = player.position - firePoint.position;
            if (Physics.Raycast(firePoint.position, direction, out hit, detectionRange, ~obstacleLayer))
            {
                if (hit.collider.CompareTag("Player") && Time.time >= nextFireTime)
                {
                    Shoot();
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(player.position - firePoint.position);
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage(damagePerBullet);
        bulletScript.SetTargetTag("Player");

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bullet.transform.forward * bulletSpeed;
    }
}

