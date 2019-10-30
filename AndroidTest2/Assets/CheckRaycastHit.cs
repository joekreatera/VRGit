using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRaycastHit : MonoBehaviour {

    public Material newMaterial;
    float viewTimer;
    GameObject selectedObject;
    public Image image;
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
        if (crashed)
        {
             GameObject crashedObject = hit.collider.gameObject;
            if (selectedObject == crashedObject)
            {
                viewTimer += Time.deltaTime;
            }
            else
            {
                viewTimer = 0;
                selectedObject = crashedObject;
            }
            
            if (viewTimer >= 5.0f) { 
                hit.collider.gameObject.GetComponent<Renderer>().material = newMaterial;
                Destroy(selectedObject);
                selectedObject = null;
                viewTimer = 0;
            }
        }
        else {
            viewTimer = 0;
            selectedObject = null;
        }
        image.fillAmount = viewTimer / 5.0f;
    }
}
