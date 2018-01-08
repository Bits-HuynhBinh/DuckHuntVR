using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabTospawn;
    public GameObject target;

    public void Spawn(int number, float timeBetweenSpawn)
    {
        StartCoroutine(SpawnADuck(number, timeBetweenSpawn));
    }


    private IEnumerator SpawnADuck(int number,float timeBetweenSpawn)
    {
        if (prefabTospawn != null)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject obj = Instantiate(prefabTospawn, transform.position, Quaternion.identity);
                obj.transform.LookAt(target.transform);
                obj.GetComponent<RhinoController>().Run(target, 6);
                
                //todo: add particle system
                yield return new WaitForSeconds(timeBetweenSpawn);
            }
        }
    }

}
