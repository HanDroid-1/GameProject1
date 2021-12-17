using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    public void PlayClick()
    {
        playerController.playerAlive = true; //다시 playerAlive를 true로 바꿔줘야 버튼을 눌렀을때 계속하기 가능
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void PauseClick()
    {
        Time.timeScale = 0;
    }
    public void quitClick()
    {
        SceneManager.LoadScene("StartScene");
        CountScore.score = 0;
    }


}
