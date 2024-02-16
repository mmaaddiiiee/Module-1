using UnityEngine;
//not used in game
public class StationEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;
    public float detectionRange = 10f;
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

        // Check if player is within detection range
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            // Check line of sight
            RaycastHit hit;
            Vector3 direction = player.position - firePoint.position;
            if (Physics.Raycast(firePoint.position, direction, out hit, detectionRange, ~obstacleLayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Player is in line of sight, shoot
                    if (Time.time >= nextFireTime)
                    {
                        Shoot();
                        nextFireTime = Time.time + 1f / fireRate;
                    }
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Vector3 direction = (player.position - firePoint.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    void OnDrawGizmosSelected()
    {
        // Draw detection range sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Check line of sight
        RaycastHit hit;
        Vector3 direction = player.position - firePoint.position;
        if (Physics.Raycast(firePoint.position, direction, out hit, detectionRange, ~obstacleLayer))
        {
            // Draw the raycast line
            Gizmos.color = Color.red;
            Gizmos.DrawLine(firePoint.position, hit.point);
        }
        else
        {
            // Draw the full line of sight
            Gizmos.color = Color.green;
            Gizmos.DrawLine(firePoint.position, firePoint.position + direction.normalized * detectionRange);
        }
    }
}
