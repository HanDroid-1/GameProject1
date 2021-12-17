using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    public static int score; //다른 클래스에서 접근할수있게 static 넣어줌
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Score : " + score.ToString();//적 처리시 1씩 증가되는 int 값을 문자로 변환하여 text에 저장(한상민)
    }
}
