using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	void Start ()
    {
        playSoundWhenCreated();
	}

    public void playSoundWhenDead()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.alienDeath);
    }

    public void playSoundWhenCreated()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.duckFirstCreated);
    }
}
