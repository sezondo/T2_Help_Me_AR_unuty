using UnityEngine;
using UnityEngine.UI;

public class AllyHealth : MonoBehaviour
{
    public bool AllyDie = false;
    public float hp = 100f;
    public RawImage imgBar;
    public Canvas inmBarAll;

    public void SetHp(int value){
        hp = value;
        imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("아군 대미지 입음");

        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            //GameObject.Find("GameManager").GetComponent<Spawn>().count--;
        }
        
        if (hp <= 0f)
        {
            AllyDie = true;
            GetComponent<Animator>().SetBool("RobotDie", true);
            Destroy(gameObject, 1);
        }
        if (hp >= 0f)
        {
            imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inmBarAll.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
