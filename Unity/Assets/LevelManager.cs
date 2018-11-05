using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    void switchLevel(int index)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        StartCoroutine(waitTillSceneLoaded(op));
    }

    void switchLevel(string levelName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);
        StartCoroutine(waitTillSceneLoaded(op));
    }

    void resetCurLevel()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(waitTillSceneLoaded(op));
    }

    IEnumerator waitTillSceneLoaded(AsyncOperation op)
    {
        while(!op.isDone)
        {
            yield return new WaitForEndOfFrame();
            Debug.Log(op.progress / .9f);
        }
    }
}