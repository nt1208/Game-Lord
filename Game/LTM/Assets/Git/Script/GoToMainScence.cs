using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoToMainScence : MonoBehaviour
{

    public void PrepareGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartGame()
    {
        Invoke("PrepareGame", 2);
    }


}
