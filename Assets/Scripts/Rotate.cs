using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float rotateSpeed;

	void Update () {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - (Time.deltaTime * rotateSpeed), 0);
	}
}
