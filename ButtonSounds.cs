using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource audioP;

    public void Hover()
    {
        audioP.Play();

    }
}
