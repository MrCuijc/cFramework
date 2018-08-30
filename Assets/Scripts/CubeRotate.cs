using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour {

    private bool canRotate;

    public bool IsCanRotate
    {
        get;set;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsCanRotate)
        {
            transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }
	}
}
