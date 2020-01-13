using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour {

    public void level1() {
        SceneManager.LoadScene("Level1");
    }

    public void level2() {
        SceneManager.LoadScene("Level2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
    }

}
