using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("time = " + Time.deltaTime);

		Debug.Log ("test frame = " + Application.targetFrameRate);

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("time = " + Time.deltaTime);
	}
}
