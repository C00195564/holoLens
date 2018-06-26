using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displaytext : MonoBehaviour {

    StageData data;
    Text text;
	// Use this for initialization
	void Start () {
        data = FindObjectOfType<DataController>().LoadData();
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
	}
	
	public void updateText(int stage)
    {
       
        text.text = data.data[stage].text;
    }
}
