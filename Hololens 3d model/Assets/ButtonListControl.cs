using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour {
    [SerializeField]
    private GameObject buttonTemplate;

    public List<GameObject> buttonList;
  
    public List<string> filenames;
    // Use this for initialization
    void Start()
    {
        DirectoryInfo directorypath = new DirectoryInfo(Application.streamingAssetsPath + "/guides/");
        FileInfo[] info = directorypath.GetFiles();

        foreach (FileInfo file in info)
        {
            if (file.Extension == ".json")
            {
                filenames.Add(file.FullName);
                GameObject temp = Instantiate(buttonTemplate);
                temp.GetComponent<ButtonListButton>().SetText(file.Name);
                temp.GetComponent<ButtonListButton>().filename = file.FullName;
                temp.SetActive(true);
                temp.transform.SetParent(buttonTemplate.transform.parent, false);
                buttonList.Add(temp);
            }
        }
    }
}
