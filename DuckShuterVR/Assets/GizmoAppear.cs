using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoAppear : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 5f);
    }
}
