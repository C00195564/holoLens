using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class partmenu : MonoBehaviour {

    public List<string> filenames;
    public List<Button> buttons;
    public Button buttonPrefab;
    // Use this for initialization
    void Start()
    {
        DirectoryInfo directorypath = new DirectoryInfo(Application.streamingAssetsPath + "/guides/");
        FileInfo[] info = directorypath.GetFiles();

        foreach (FileInfo file in info)
        {
            if (file.Extension == ".json")
            {
                Debug.Log(file.FullName);
                filenames.Add(file.FullName);
            }
            //Button temp = buttonPrefab;
            //temp.transform.SetParent(null);
            //temp.
            //buttons.Add(temp);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

   
}
