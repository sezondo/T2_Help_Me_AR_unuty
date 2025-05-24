using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject p;
    float time;
    bool binRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p = GameObject.Find("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdf");
        if (other.gameObject == p)
        {
            binRange = true;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == p)
        {
            binRange = false;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f && binRange)
        {
            Debug.Log("적 접촉");
            time = 0;
            p.GetComponent<PlayerHealth>().Damage(50);
            if (p.GetComponent<PlayerHealth>().hp <= 0)
            {
                GetComponent<Animator>().SetTrigger("PlayerDeath"); // 이거 객체 지향 원칙 어김 이라믄 안대
            }
        }
    }
}
