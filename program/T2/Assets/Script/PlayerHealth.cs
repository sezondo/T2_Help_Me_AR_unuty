using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Vector3 posRespawn;
    public int hp = 100;
    public bool bDamage = false;
    //public RawImage imgDamage;
    public RawImage imgBar;
    public bool playerDie;

    public AudioClip PlayerDieSound;
    public AudioSource PlayerDieSoundSource;




    public void SetHp(int value){
        hp = value;
        imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);
    }

    /*
    public void Respawn(){
        hp = 100;

        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");

        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;
        imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);
    }
    */
    public void Damage(int amount){
        if (hp <= 0)
        {
            return;
        }
        bDamage = true;
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            GetComponent<Animator>().SetBool("PlayerDie", true);
            PlayerDieSoundSource.PlayOneShot(PlayerDieSound); 
            Destroy(gameObject,2);
        }
        imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);

   
        if (hp<=0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<PlayerMove>().enabled = false;
            //GetComponent<PlayerAttack>().enabled = false;

            //Invoke("Respawn", 3);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posRespawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bDamage)
        {
            //imgDamage.color = new Color(1,0,0,1);
        }
        else
        {
            //imgDamage.color = Color.Lerp(imgDamage.color,Color.clear,5*Time.deltaTime);
        }
        bDamage = false;
        
        if (hp <= 0)playerDie = true;
        
        if (playerDie)Die();
        
    }

    public void Die(){

        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
