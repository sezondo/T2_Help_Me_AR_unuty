using UnityEngine;

public class AllyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, lifeTime); // 수명 끝나면 자동 삭제
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            return;
        }

        Debug.Log("총알 충돌 대상: " + other.name + ", 태그: " + other.tag);
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.Damage(damage);
            }
        }
        Destroy(gameObject);
    }
    
}
