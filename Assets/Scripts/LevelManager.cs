using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int nextIndex = SceneManager.sceneCountInBuildSettings - 1;


        if (nextSceneIndex <= nextIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        if (nextSceneIndex > nextIndex)
        {
            SceneManager.LoadScene(0);
        }
    }
}
