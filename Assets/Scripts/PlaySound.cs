using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect.Play();
    }
}
