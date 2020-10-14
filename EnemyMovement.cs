using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

    public float enemySpeed = 10f;

    public float starthealth = 10;
    private float health;
    public int value = 20;

    private Transform target;
    public int wavepointIndex = 0;

    public Image healthBar;

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public AudioSource hit;
    public AudioClip death;
    
    public float countdown;

    public static bool mute;

    private bool isDead = false;

    private void Start()
    {
        target = Waypoints.points[0];
        health = starthealth;
        Application.targetFrameRate = 60;
        instance = this;
    }

    public void TakeDamage (int amount, float speeds)
    {
        health -= amount;
        enemySpeed -= speeds;

        if (enemySpeed < 9f && countdown <= 0f)
        {
            countdown = 4f;
        }
      
       

        healthBar.fillAmount = health/starthealth;

        if (mute == false)
        {
            hit.Play();
        }
       

        if (health <= 0 && !isDead)
        {  
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (mute == false)
        {
            AudioSource.PlayClipAtPoint(death, new Vector3(71.0f, 20.0f, 49.0f), 0.75f);
        }

        PlayerStats.Money += value;

        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);    
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemySpeed * Time.deltaTime, Space.World);

        Vector3 dir1 = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (Vector3.Distance(transform.position, target.position) <= 0.85f)
        {
            GetNextWaypoint();
        }

        if (countdown >= 0f)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0.02f)
        {
            enemySpeed = 10f;
        }

    

        if (enemySpeed <= 1.9f)
        {
            countdown = 4f;
            enemySpeed = 2f;
        }

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length -1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

}
