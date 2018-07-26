using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class LookAt : MonoBehaviour, IFocusable {
    public Shader normalshader;
    public Shader HighlightShader;
    public GameObject Text;

	public void OnFocusEnter()
    {
        //Debug.Log("enteringfocus");
        Text.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().material.shader = HighlightShader;
    }

    public void OnFocusExit()
    {
        //Debug.Log("Leaving focus");
        Text.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().material.shader = normalshader;
    }
}
