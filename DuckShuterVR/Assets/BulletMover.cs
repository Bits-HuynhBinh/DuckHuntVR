using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;

    public void fire(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction*speed);
        StartCoroutine(destroyLater());
    }



    private IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
