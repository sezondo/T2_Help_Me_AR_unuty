using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public RawImage imgBar;
    int hp = 100;
    public bool enemyDie = false;

    public void Damage(int amount){
        //Debug.Log("적 대미지 입음");
        if (hp <= 0)
        {
            return;
        }

        hp -= amount;

        if (hp <= 0)
        {
            hp = 0;
        }

        imgBar.transform.localScale = new Vector3(hp/100.0f, 1,1);
        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<NavMeshAgent>().enabled = false;

            GetComponent<Animator>().SetBool("EnemyDie", true);

            Destroy(gameObject,1);
            //GameObject.Find("GameManager").GetComponent<Spawn>().count--;
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)enemyDie=true;
    }
}
