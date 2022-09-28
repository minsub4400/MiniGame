using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManeger : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip BGM;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        audioSource.PlayOneShot(BGM);
    }


}
