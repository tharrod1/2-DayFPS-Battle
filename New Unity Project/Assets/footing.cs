using UnityEngine;
using System.Collections;

public class footing : MonoBehaviour {
    public bool onFloor = false;


    // Use this for initialization
    void OnCollisionEnter(Collision col)
    {

        onFloor = true;

    }

    void OnCollisionExit(Collision col)
    {
        onFloor = false;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
