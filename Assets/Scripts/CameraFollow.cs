using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraFollow : MonoBehaviour {

	[SerializeField] Transform target;
	//[SerializeField] float smoothing = 5f;

	Vector3 offset;

	Quaternion qOffset;


	void Awake()
	{
		Assert.IsNotNull(target);
	}

	// Use this for initialization
	void Start () {
		
		offset = transform.position - target.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + offset;

		transform.rotation = Quaternion.Euler(target.rotation.eulerAngles.x + 20, target.rotation.eulerAngles.y, target.rotation.eulerAngles.z);
       // transform.LookAt(target);
		Debug.Log(offset);
		
	}
}
