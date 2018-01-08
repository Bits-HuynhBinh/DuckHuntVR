using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoController : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public float health;
    public ParticleSystem deadParticle;

    private string isRunning = "isRunning";
    private string Attacking = "isAttacking";
    private string isHit = "isHit";
    private string isDead = "isDead";

    private Animator anim;

    public void ForceGetAnimator()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }


    private void Start()
    {
        transform.LookAt(target.transform);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null && speed > 0)
        {           
            //Vector3 direction =  target.transform.position - transform.position;
            //Vector3 nornalVector = direction.normalized;

            if (checkForDistance())
            {
                //transform.LookAt(target.transform);
                //Debug.Log("Near");
            }
            else
            {
                transform.LookAt(target.transform);
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                //transform.Translate(nornalVector * speed * Time.deltaTime);            
                //Debug.Log("Far");
            }
        }
        else if (target != null && speed == 0)
        {
            //transform.LookAt(target.transform);
        }
        else
        {
            //transform.LookAt(target.transform);
        }


        checkIfRhinoShouldAttackPlayer();
    }

    public void getHit(float damage)
    {
        animHit();

        // add bloody affect
        ParticleSystem particleSystem = Instantiate(deadParticle, transform.position, Quaternion.identity);
        particleSystem.Play();
        GetComponent<SoundPlayer>().playSoundWhenDead();

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

    public void Dead()
    {
        GameManager.Instance.decreaseEnemyOnSceneCount();
        GameManager.Instance.decreaseEnemyWhenDead();

        animDead();

        //disable game object first
        gameObject.SetActive(false);
        // destroy game object after 2s
        Destroy(gameObject, 1f);
    }


    public bool checkForDistance()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= 8.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void checkIfRhinoShouldAttackPlayer()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= 8.5)
        {
            animAttack();
        }
        else
        {
            animStopAttack();
            animRun();
        }
    }

    public void Run(GameObject target, float speed)
    {
        this.target = target;
        this.speed = speed;

        animRun();
    }


    public void animRun()
    {
        ForceGetAnimator();
        anim.SetBool(isRunning, true);
    }

    public void animAttack()
    {
        ForceGetAnimator();
        anim.SetBool(isRunning, false);
        anim.SetBool(Attacking, true);
    }

    public void animStopAttack()
    {
        ForceGetAnimator();
        anim.SetBool(Attacking, false);
    }

    public void animHit()
    {
        ForceGetAnimator();
        anim.SetTrigger(isHit);
    }

    public void animDead()
    {
        ForceGetAnimator();
        anim.SetBool(isDead, true);
        Destroy(gameObject, 1f);
    }




}
