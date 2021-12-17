using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl_Start : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayClick()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void QuitClick()
    {
        Application.Quit();
    }



}
