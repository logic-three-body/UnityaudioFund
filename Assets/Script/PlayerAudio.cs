using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlayerAudio : MonoBehaviour {
	public AudioClip bumpSound;//冰壶直接碰撞的声音

	public AudioSource audioS=null;//音频源

    public AudioMixerSnapshot idle=null;
    public AudioMixerSnapshot auxin=null;    
    public AudioMixerSnapshot Amidle=null;
    public AudioMixerSnapshot Amin=null;

    public float fade_test=0.5f;


    //用于脚步声
    public AudioClip[] grassSteps;
    public AudioClip[] woodSteps;
    public AudioClip[] hardSteps;


	private void OnTriggerEnter(Collider other)
    {
		if(other.CompareTag("Water"))
        {
            audioS.PlayOneShot(bumpSound);
        }

        if(other.CompareTag("EnemyZone"))
        {
            //print("hey,you comein");
            auxin.TransitionTo(fade_test);//音效的淡入淡出过渡，参数为淡入淡出时间
        }


        if (other.CompareTag("AmbianceZone"))
        {
            //print("hey,you comein");
            Amin.TransitionTo(fade_test);//音效的淡入淡出过渡，参数为淡入淡出时间
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(bumpSound);
        }

        if (other.CompareTag("EnemyZone"))
        {
            idle.TransitionTo(fade_test);
            //print("hey,you exit");
        }
        if (other.CompareTag("AmbianceZone"))
        {
            Amidle.TransitionTo(fade_test);
            //print("hey,you exit");
        }
    }

    public void FootStep()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position,-transform.up);
        int r = Random.Range(0, 3);
        if(Physics.Raycast(ray,out hit,1f))
        {
            switch(hit.transform.tag)
            {
                case "grass":
                    audioS.PlayOneShot(grassSteps[r]);
                    break;
                case "wood":
                    audioS.PlayOneShot(woodSteps[r]);
                    break;
                case "hard":
                    audioS.PlayOneShot(hardSteps[r]);
                    break;
                default:
                    audioS.PlayOneShot(grassSteps[r]);
                    break;
            }
        }
    }
}
