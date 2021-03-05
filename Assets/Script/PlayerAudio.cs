using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {
	public AudioClip bumpSound;//冰壶直接碰撞的声音

	public AudioSource audioS=null;//音频源

	private void OnTriggerEnter(Collider other)
    {
		if(other.CompareTag("Water"))
        {
            audioS.PlayOneShot(bumpSound);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(bumpSound);
        }
    }
}
