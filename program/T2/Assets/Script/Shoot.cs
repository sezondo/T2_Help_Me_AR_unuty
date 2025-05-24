using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject fireEffectPrefab;
    public void Fire()
    {
         
        if (fireEffectPrefab != null)
        {
            GameObject effect = Instantiate(fireEffectPrefab, firePoint.position, Quaternion.identity);
            Destroy(effect, 0.3f);
        }
        
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//총알생성성
        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
