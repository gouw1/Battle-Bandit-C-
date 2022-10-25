using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip slashSound, collectSound;
    private static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        slashSound = Resources.Load<AudioClip>("slash");
        collectSound = Resources.Load<AudioClip>("collect");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "slash":
                audioSrc.PlayOneShot(slashSound);
                break;

            case "collect":
                audioSrc.PlayOneShot(collectSound);
                break;

        }
    }
}
