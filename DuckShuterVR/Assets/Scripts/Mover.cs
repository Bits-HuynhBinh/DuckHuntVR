using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public int speed;
    public int timeToDestroyObject = 20;
    private Rigidbody rb;


    //public enum XorZ { X, Z};

    //public XorZ xOrZ;
    [HideInInspector]
    public GameObject target;


	// Use this for initialization
	void Start ()
    {
        Vector3 Force = new Vector3(0, speed, 0);

        //int forceDirection = Random.Range(100, speed / 5);

        Vector3 direction = target.transform.position - transform.position;
        direction.y = speed;

        //int isLeftOrRight = Random.Range(1, 3);
        //if(isLeftOrRight == 1)
        //{
        //    Force.x = forceDirection;
        //}
        //else if(isLeftOrRight == 2)
        //{
        //    Force.z = forceDirection;
        //}

        //if(xOrZ == XorZ.X)
        //{
        //    Force.x = forceDirection;
        //}
        //else if (xOrZ == XorZ.Z)
        //{
        //    Force.z = forceDirection;
        //}

       

        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction);


        StartCoroutine(destroyLater());
	}


    private IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(timeToDestroyObject);
        Destroy(gameObject);
    }


}
