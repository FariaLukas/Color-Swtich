using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{

    public AudioSource source;
    public AudioSource loopSource;
    public AudioSource touchSource;
    public AudioClip star, changeColor, touch, death;

    public void OnSound(AudioClip clip)
    {
        if(clip == touch)
        {
            touchSource.volume = 0.1f;
            touchSource.pitch = (Random.Range(0.8f, 1.3f));
            touchSource.PlayOneShot(clip);
        }
        else
        {

            source.PlayOneShot(clip);
        }
        
    }

    public void OnDeath()
    {
        loopSource.Stop();
        source.Stop();
        source.pitch = 1;
        source.PlayOneShot(death);
    }

}
