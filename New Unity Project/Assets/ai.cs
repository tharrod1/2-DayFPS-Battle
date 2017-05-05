/*using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {

    public int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GameObject closestgrass = Find();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3( closestgrass.transform.position.x, 0.89F, closestgrass.transform.position.z), 0.125F);
	}
    GameObject Find()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag ("Grass");
        GameObject closest = null;
        Vector3 position = transform.position;
        float adistance = Mathf.Infinity;
        foreach (GameObject go in gos)
        {
            if (go.GetComponent<NewBehaviourScript>().farmed == false)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if(curDistance < adistance)
                {
                    closest = go;
                    adistance = curDistance;
                }
            }
        }
        return closest;
    }
}
*/