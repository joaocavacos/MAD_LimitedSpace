using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : Singleton<GameDirector>
{
    public bool canPlay = true;

    public void ChangeGameState(bool state) => canPlay = state;

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main Menu");
    }
}
