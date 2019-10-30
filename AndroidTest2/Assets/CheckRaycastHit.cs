using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRaycastHit : MonoBehaviour {

    public Material newMaterial;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        bool crashed = Physics.Raycast(this.transform.position,
                                        this.transform.TransformDirection(Vector3.forward),
                                        out hit,
                                        Mathf.Infinity
                                        );
        if (crashed) {
            Debug.Log("Crashed with " + hit.collider.gameObject);
            hit.collider.gameObject.GetComponent<Renderer>().material = newMaterial;
        }
	}
}
