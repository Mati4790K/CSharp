using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turret : MonoBehaviour
{
    [SerializeField] private Animator archer;
    [SerializeField] private Animator bow;
    [SerializeField] private Animator mage;
    [SerializeField] private Animator freezy;


    public static Turret zadziala;

    private Transform target;

    [Header("Attributes")]

    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 20f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public string enemyTag2;

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        zadziala = this;
    }

    void UpdateTarget()
    {

        GameObject[] fenemies = GameObject.FindGameObjectsWithTag(enemyTag2);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        GameObject[] final_array = enemies.Concat(fenemies).ToArray();

        


        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in final_array)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;

        }
      

        if (fireCountdown <= 0.25f || fireCountdown >= 1.4f)
        {
            Anim();
        }

        if (fireCountdown >= 0.37f && fireCountdown <= 0.60f)
        {
            AnimEnd();
        }
        fireCountdown -= Time.deltaTime;
    }

    void Anim()
    {
        if (gameObject.CompareTag("Archer"))
        {
            archer.SetBool("Shot", true);
            bow.SetBool("BowShot", true);
        }
        else if (gameObject.CompareTag("Mage"))
        {
            mage.SetBool("Shot", true);
        }
        else if (gameObject.CompareTag("Freezy"))
        {
            freezy.SetBool("Shot", true);
        }
    }

    void AnimEnd()
    {
        if (gameObject.CompareTag("Archer"))
        {
            archer.SetBool("Shot", false);
            bow.SetBool("BowShot", false);
        }
        else if (gameObject.CompareTag("Mage"))
        {
            mage.SetBool("Shot", false);
        }
        else if (gameObject.CompareTag("Freezy"))
        {
            freezy.SetBool("Shot", false);
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

     

        if (bullet != null)
            bullet.Seek(target);


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
