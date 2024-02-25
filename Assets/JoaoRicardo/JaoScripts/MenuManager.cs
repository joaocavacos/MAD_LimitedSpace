using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsMenu;
    
    public void PlayClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    public void CreditsClicked()
    {
        creditsMenu.SetActive(true);
    }
}
