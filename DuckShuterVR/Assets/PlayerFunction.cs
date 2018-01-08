using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFunction : MonoBehaviour
{

    public float health = 100f;
    public Image bloodImage;

    private bool isAttackingByRhino = false;
    private float attackInterval = 2f;

    private void Update()
    {
        attackInterval -= Time.deltaTime;

        if(attackInterval <= 0)
        {
            isAttackingByRhino = true;
        }

    }


    public void hurtPlayer(float damage)
    {
        Debug.Log("Hurt player " + damage.ToString());
        GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.hurtPlayer);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Rhino"))
        {
            //Debug.Log(other.GetType());

            System.Type type = other.GetType();

            if (type.FullName.Equals("UnityEngine.SphereCollider"))
            {
                if(isAttackingByRhino == true)
                {
                    Debug.Log("Rhino HIT player");
                    // minus player health
                    // red the screen
                    // and check for dead
                    GetHit(10);
                    GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.hurtPlayer);
                    isAttackingByRhino = false;
                    attackInterval = 2f;
                }
                
            }
        }
        
    }

    public void RedScreen(bool getDamage)
    {
        if (getDamage)
        {
            Color Opaque = new Color(1, 1, 1, 1);
            bloodImage.color = Color.Lerp(Color.red, Opaque, 20 * Time.deltaTime);
            if (bloodImage.color.a >= 0.8) //Almost Opaque, close enough
            {
                getDamage = false;
            }
        }

        if (!getDamage)
        {
            Color Transparent = new Color(1, 1, 1, 0);
            bloodImage.color = Color.Lerp(Color.red, Transparent, 20 * Time.deltaTime);
        }
    }


    public IEnumerator ResetRedScreen()
    {
        yield return new WaitForSeconds(0.5f);
        RedScreen(false);
    }

    public void Dead()
    {
        gameObject.SetActive(false);
        Debug.Log("Player dead");

        StartCoroutine(reloadScene());
    }

    public IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    public void GetHit(float damage)
    {
        RedScreen(true);
        StartCoroutine(ResetRedScreen());

        //minus health
        if (health > 0)
        {
            health = health - damage;
        }

        // check health == 0 -> dead
        if (health <= 0)
        {
            Dead();
        }
        Debug.Log(health);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Rhino"))
    //    {
    //        Debug.Log(collision.collider.name);
    //    }
    //}

}
