using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float fireCooldown = 2f;
    public float fireRange = 25f;

    private float lastFireTime = 0f;
    private GameObject target;
    public AudioClip ShooterSound;
    public AudioSource ShooterSoundSource;

    void Update()
    {
        target = FindNearestTarget();
        if (target != null)
        {
            float dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist <= fireRange && Time.time - lastFireTime >= fireCooldown)
            {
                ShooterSoundSource.PlayOneShot(ShooterSound); 
                foreach (var fp in GetComponentsInChildren<Shoot>())
                    {
                        fp.Fire();
                    }
                lastFireTime = Time.time;
            }
        }
    }

    
    GameObject FindNearestTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Player"); // 또는 "Ally" 로 바꾸면 npc 공격 가능
        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject t in possibleTargets)
        {
            float d = Vector3.Distance(transform.position, t.transform.position);
            if (d < minDist)
            {
                minDist = d;
                nearest = t;
            }
        }

        return nearest;
    }
}
