using UnityEngine;
using UnityEngine.AI;

public class AllyFollower : MonoBehaviour
{

    private GameObject player;
    private AllyActivator activator;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        activator = GetComponent<AllyActivator>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<AllyHealth>().AllyDie) return;
        if (activator != null && activator.isActivated && player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
