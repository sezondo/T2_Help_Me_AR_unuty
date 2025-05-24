using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    LineRenderer line;
    Transform shootPoint;
    public AudioClip clipGunShot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
        shootPoint = transform.Find("ShootPoint");
    }

    public void Fire(){

        GetComponent<AudioSource>().PlayOneShot(clipGunShot);

        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
            if (e != null)
            {
                Debug.Log("총알ㄹ사");
                e.Damage(50);
                line.enabled = true;
                line.SetPosition(0, shootPoint.position);
                line.SetPosition(1, hit.point);
            }
        }else
        {
            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1, shootPoint.position + ray.direction*100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (line.enabled)
        {
            timer += Time.deltaTime;
            if (timer > 0.05f)
            {
                timer = 0;
                line.enabled = false;
            }
        }
    }
}
