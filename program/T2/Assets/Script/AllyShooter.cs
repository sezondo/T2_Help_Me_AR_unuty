using UnityEngine;

public class AllyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float attackCooldown = 1.5f;
    public float fireRange = 25f;
    //public GameObject fireEffectPrefab;

    private AllyActivator activator;
    private float lastAttackTime = 0f;
    private Transform currentTarget;
    public AudioClip ShooterSound;
    public AudioSource ShooterSoundSource;

    void Start()
    {
        activator = GetComponent<AllyActivator>();
    }

    void Update()
    {
        if(GetComponent<AllyHealth>().AllyDie) return;

        //GetComponent<Animator>().SetBool("RobotShoot", false);
        if (activator != null && activator.isActivated)
        {
            currentTarget = FindNearestEnemyInRange(fireRange);

            if (currentTarget != null)
            {
                //  적 바라보기 (수평 회전만)
                Vector3 dir = currentTarget.position - transform.position;
                dir.y = 0;
                if (dir != Vector3.zero)
                {
                    Quaternion rot = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10f);
                }

                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    ShooterSoundSource.PlayOneShot(ShooterSound); 
                    GetComponent<Animator>().SetBool("RobotShoot", true);
                    foreach (var fp in GetComponentsInChildren<Shoot>()) // 이 오브젝트 자신과 자식 오브젝트들에서 타입 Shoot 컴포넌트 모두 찾아서 배열로 반환환
                    {
                        
                        fp.Fire();
                    }
                    lastAttackTime = Time.time;
                }
            }
        }
    }
/*
    void Shoot()
    {
         이펙트 생성
        if (fireEffectPrefab != null)
        {
            GameObject effect = Instantiate(fireEffectPrefab, firePoint.position, Quaternion.identity);
            Destroy(effect, 0.3f);
        }
        
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//총알생성성
        

    }
*/
    Transform FindNearestEnemyInRange(float range)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearest = null;
        float minDist = Mathf.Infinity; // 초기 거리 무한대

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist && dist <= range)
            {
                minDist = dist;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }
}
