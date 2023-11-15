using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {get; private set;}

    AudioSource source;
    public AudioClip gameOver;

    public AudioClip jump;
    public AudioClip getStar;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        source.PlayOneShot(gameOver);
    }

    public void JumpSFX()
    {
        source.PlayOneShot(jump);
    }

    public void GetStar()
    {
        source.PlayOneShot(getStar);
    }
    
}
