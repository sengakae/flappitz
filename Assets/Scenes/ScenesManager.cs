using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public enum Scene {
        MainMenu,
        Game
    }

    public void LoadNewGame() {
        SceneManager.LoadScene(Scene.Game.ToString());
    }
}
