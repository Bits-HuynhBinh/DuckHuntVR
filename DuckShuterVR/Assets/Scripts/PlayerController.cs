using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController charController;


    void Awake()
    {

        charController = GetComponent<CharacterController>();

    }

 

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        charController.SimpleMove(moveDirection * 2);
    }
}
