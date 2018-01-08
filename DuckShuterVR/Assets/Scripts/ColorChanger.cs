using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public Material matEnter;
    public Material matExit;

    public ParticleSystem particle;

    public void changeColor(bool isChange)
    {
        if(isChange)
        {
            GetComponent<MeshRenderer>().material = matEnter;
        }
        else
        {
            GetComponent<MeshRenderer>().material = matExit;
        }
    }

    public void dead()
    {
        ParticleSystem particleSystem = Instantiate(particle, transform.position, Quaternion.identity);
        particleSystem.Play();
        GetComponent<SoundPlayer>().playSoundWhenDead();

        //destroy it later to let particle and sound have time to play
        StartCoroutine(destroyGameObject(0.5f));
        //disable game object first
        gameObject.SetActive(false);
        
    }


    public IEnumerator destroyGameObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }



}
