using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
    public int SceneToGoTo;
	// Use this for initialization
	void Start () {
        StartCoroutine("GoTo", SceneToGoTo);
	}

    IEnumerator GoTo(int loadindex)
    {
        int unload = SceneManager.GetActiveScene().buildIndex;
        var loading = SceneManager.LoadSceneAsync(loadindex);
        yield return loading;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(loadindex));
        SceneManager.UnloadSceneAsync(unload);
    }
}
