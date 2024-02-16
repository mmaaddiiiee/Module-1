using UnityEngine;
//help from chatgpt, prompted it to help with pooling, but 
//and to add some specfic conditions like the Terrain making them return to pool
public class Bullet : MonoBehaviour
{
    private int damage;
    private string targetTag;
    private bool canMove = true;

    public float bulletSpeed = 10f;

    void OnEnable()
    {
        Invoke("ReturnToPool", 9f);
    }

    void Update()
    {
        if (canMove)
            Move();
    }

    void Move()
    {
        // Move the bullet along the x and z axes
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && canMove)
        {
            // Handle damage to enemies
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(damage);

            ReturnToPool();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            ReturnToPool();
        }
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    public void SetTargetTag(string tag)
    {
        targetTag = tag;
    }

    void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}

