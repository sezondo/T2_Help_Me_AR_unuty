using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            return;
        }


        Debug.Log("총알 충돌 대상: " + other.name + ", 태그: " + other.tag);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.Damage(damage);
        }
        else if (other.CompareTag("Ally"))
        {
            other.GetComponent<AllyHealth>()?.TakeDamage(damage);
        }
        
        

        Destroy(gameObject);
    }
}
