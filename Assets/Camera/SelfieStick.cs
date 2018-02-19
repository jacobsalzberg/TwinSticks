using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    private GameObject player;
    private Vector3 armRotation;
    public float panSpeed = 10f;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () { //movement --> update //rendering the results of moving --> late update
        //print("RHoriz" + Input.GetAxis("RHoriz"));
        armRotation.z += Input.GetAxis("RVert") * panSpeed;
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
	}
}
