using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stage 
{
    public Vector3[] position;
    public Quaternion[] Rotation;
    public bool[] alive;
    public string text;
}

[System.Serializable]
public class StageData
{
    public string[] PartNames;
    public Stage[] data;
}
