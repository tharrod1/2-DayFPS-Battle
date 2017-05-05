using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 40);
        Destroy(gameObject, 20);
	}
    void OnCollisionStay()
    {
        Destroy(gameObject);
    }
}
