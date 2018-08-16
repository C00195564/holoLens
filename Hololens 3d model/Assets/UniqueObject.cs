using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueObject : MonoBehaviour {
    public static GameObject cameraInstance;

	// Use this for initialization
	void Awake () {
		if(cameraInstance == null)
        {
            cameraInstance = gameObject;
        }
        else
        {
            DestroyObject(gameObject);
        }
	}
}
