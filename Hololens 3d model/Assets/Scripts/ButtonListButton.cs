using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class ButtonListButton : MonoBehaviour {

    [SerializeField]
    private Text myText;
    private Button butt;
    public string filename;

	public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void OnClick()
    {
        //Debug.Log(myText);
        GameObject.FindGameObjectWithTag("Respawn").GetComponent<StringHolder>().filepath = filename;
        StartCoroutine("GotoScene", 3);
    }


    IEnumerator GotoScene(int loadindex)
    {
        int unload = SceneManager.GetActiveScene().buildIndex;
        var loading = SceneManager.LoadSceneAsync(loadindex);
        yield return loading;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(loadindex));
        SceneManager.UnloadSceneAsync(unload);
    }
}
