using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitClicked()
    {
        Application.Quit();
    }
}
