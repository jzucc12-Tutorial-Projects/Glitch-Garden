using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float timeDelay = 4f;
    int currentSceneIndex;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
            StartCoroutine(LoadStartMenu());
    }

    public IEnumerator LoadStartMenu()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadNextLevel()
    {
        int inc = 1 + (currentSceneIndex == 1 ? 1 : 0);
        SceneManager.LoadScene(currentSceneIndex + inc);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Options()
    {
        SceneManager.LoadScene(2);
    }
}
