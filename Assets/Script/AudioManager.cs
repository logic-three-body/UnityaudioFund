using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager manager;

    public AudioSource mainMusic;
    public AudioSource auxMusic;
    public AudioSource ambSound;

    private void Awake()
    {
        manager = this;
    }
    

}
