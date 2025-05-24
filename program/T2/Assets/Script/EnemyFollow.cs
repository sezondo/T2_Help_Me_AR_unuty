using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    private GameObject player;
    private PlayerHealth playerSave;
    private EnemyHealth enemyHealth;
    private NavMeshAgent agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null) playerSave = player.GetComponent<PlayerHealth>();

        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        //Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        

        if (player != null && !playerSave.playerDie && !enemyHealth.enemyDie)
        {
            agent.SetDestination(player.transform.position);
            GetComponent<Animator>().SetBool("EnemyWalk", true);

            // 플레이어가 멈출 거리 안에 있으면 직접 바라보기
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist <= agent.stoppingDistance)
            {
                GetComponent<Animator>().SetBool("EnemyWalk", false);
                Vector3 dir = player.transform.position - transform.position;
                dir.y = 0;
                if (dir != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
                }
            }
        }
    }
}
