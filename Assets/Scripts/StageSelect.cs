using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void playMountain()
    {
        SceneManager.LoadScene(2);
    }
    public void playSky()
    {
        SceneManager.LoadScene(3);
    }
    public void playJungle()
    {
        SceneManager.LoadScene(4);
    }
    public void playMenu()
    {
        SceneManager.LoadScene(0);
    }
}
