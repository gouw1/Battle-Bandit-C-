using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public CharacterController2D controller;
	public float runSpeed = 40f;
    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }
	
	void FixUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
	}
	
	
}
