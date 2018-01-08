using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgePlayer : MonoBehaviour
{
    public float howMuchDamage = 1f;
    // if colide with 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //play sound when hurt
            GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.hurtPlayer);
            //todo: hurt player
            collision.gameObject.GetComponent<PlayerFunction>().hurtPlayer(howMuchDamage);

        }
        
    }

}
