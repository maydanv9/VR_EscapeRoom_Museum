using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource ass;

    public void PlaySound()
    {
        ass.Play();
    }
}
