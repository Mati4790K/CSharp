using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage = 5;
    public float slowDownSpeedEnemy;
    public float explosionRadius = 0.0f;


    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {          
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

       
    }

    void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 4.2f);

        if (explosionRadius > 0.0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }

        }
    }


    void Damage (Transform enemy)
    {

        EnemyMovement e = enemy.GetComponent<EnemyMovement>();
        FlyingEnemyMovement f = enemy.GetComponent<FlyingEnemyMovement>();

        if (e != null)
        {
            e.TakeDamage(damage,slowDownSpeedEnemy);
        }
        else if (f != null)
        {
            f.TakeDamage(damage, slowDownSpeedEnemy);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
