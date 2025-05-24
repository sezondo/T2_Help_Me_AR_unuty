using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveFollow : MonoBehaviour
{

    Transform p;
    NavMeshAgent nav;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    

    // Update is called once per frame
    void Update()
    {   
        if (nav.isActiveAndEnabled)
        {
            nav.SetDestination(p.position);
        }
        
    }
}
