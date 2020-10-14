using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            int index = Random.Range(0, shoot.Length);
            shootClip = shoot[index];
            audioSource.clip = shootClip;
            audioSource.Play();
        }
    }
}
