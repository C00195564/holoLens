using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class EnableAR : MonoBehaviour {

    public VuforiaBehaviour ar;
	// Use this for initialization
	void Start () {
        ar = GameObject.FindObjectOfType<VuforiaBehaviour>();
        ar.enabled = true;
	}
	
	// Update is called once per frame
	void OnDestroy() {
        ar.enabled = false;
	}
}
