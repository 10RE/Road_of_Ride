using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public string firstScene;
    public string secondScene;
    public string[] scene;
    private int nextScene = 0;
    private string prevScene;
    private string curScene;
    private bool connectionFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        prevScene = firstScene;
        curScene = secondScene;
        //SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);
        SceneManager.LoadScene(secondScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(prevScene));
    }

    public void swapScene()
    {
        SceneManager.UnloadSceneAsync(prevScene);
        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(scene[nextScene], LoadSceneMode.Additive);
        prevScene = curScene;
        curScene = scene[nextScene];
        nextScene++;
        StartCoroutine(HitTimer(asyncLoadLevel));
    }
    IEnumerator HitTimer(AsyncOperation asyncLoadLevel)
    {
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }
        if (connectionFlag)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(curScene));
        }
        connectionFlag = !connectionFlag;
    }
}
