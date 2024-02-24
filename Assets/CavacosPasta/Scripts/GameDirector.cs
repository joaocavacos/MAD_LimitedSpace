using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : Singleton<GameDirector>
{
    public bool canPlay = true;

    public void ChangeGameState(bool state) => canPlay = state;
}
