using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoundHandler : MonoBehaviour
{
    public AudioClip keyClick;
    private AudioSource clickSource;
    private GameObject keyboard;

    void Start()
    {
        clickSource = gameObject.AddComponent<AudioSource>();
        //keyboard = GameObject.Find("Keyboard");
        //keyboard.SetActive(false);
        
    }

    public void PlayClickSound()
    {
        clickSource.PlayOneShot(keyClick);
    }
}
