using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string mainScene = "Main";
    public string challegneOneScene = "AR Mesh Generator";
    public string challengeTwoScene = "Sin Curve";

    public void OnLoadMain()
    {
        LoadScene(mainScene);
    }

    public void OnLoadChallengeOne()
    {
        LoadScene(challegneOneScene);
    }

    public void OnLoadChallengeTwo()
    {
        LoadScene(challengeTwoScene);
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
