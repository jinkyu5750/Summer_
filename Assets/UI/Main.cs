    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("ExitScene");
    }

    public void ReturnToMainButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
