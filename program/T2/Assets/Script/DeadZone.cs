using UnityEngine;

public class DeadZone : MonoBehaviour
{
    GameObject p;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            p.GetComponent<PlayerHealth>().Damage(990);

        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
