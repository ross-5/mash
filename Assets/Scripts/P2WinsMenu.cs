using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P2WinsMenu : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene(1);
    }
    public void quit()
    {
        SceneManager.LoadScene(0);
    }
}
