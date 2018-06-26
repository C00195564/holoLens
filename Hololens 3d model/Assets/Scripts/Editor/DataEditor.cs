using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataEditor : EditorWindow
{
    public StageData stageData;
    Vector2 vsbarvalue;
    string DataFileName = "data.json";

    [MenuItem ("Window/Data Editor")]
    static void init()
    {
        DataEditor window = (DataEditor)EditorWindow.GetWindow(typeof(DataEditor));
        
        window.Show();
    }

    void OnGUI()
    {
        vsbarvalue = GUILayout.BeginScrollView(vsbarvalue);
       
        if(stageData != null)
        {
            SerializedObject Object = new SerializedObject(this);
            SerializedProperty  Property = Object.FindProperty("stageData");

            EditorGUILayout.PropertyField(Property, true);

            Object.ApplyModifiedProperties();

            if(GUILayout.Button("Save Data"))
            {
                SaveData();
            }
        }

        if(GUILayout.Button("Load Data"))
        {
            LoadData();
        }
        GUILayout.EndScrollView();
    }

    private void LoadData()
    {
        Debug.Log("Loading data.json");
        string filepath = Path.Combine(Application.streamingAssetsPath, DataFileName);
        if (File.Exists(filepath))
        {
            string jsonData = File.ReadAllText(filepath);
            stageData = JsonUtility.FromJson<StageData>(jsonData);

        }
        else
        {
            stageData = new StageData();
        }
    }

    private void SaveData()
    {
        Debug.Log("saving data json");
        string jsondata = JsonUtility.ToJson(stageData);
        string filepath = Path.Combine(Application.streamingAssetsPath, DataFileName);
        File.WriteAllText(filepath, jsondata);
    }
	

}
