using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource bounce;
    public AudioSource point;
    public AudioSource death;

    public void PlayBounce()
    {
        bounce.Play();
    }
    
    public void PlayPoint()
    {
        point.Play();
    }

    public void PlayDeath()
    {
        death.Play();
    }
}
