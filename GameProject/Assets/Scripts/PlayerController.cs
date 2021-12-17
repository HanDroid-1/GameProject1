using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float x, z;
    float speed = 10.0f;
    
    float JumpPower = 5.0f;
    Transform tr;
   
    public GameObject panel = null;
    public bool playerAlive = true;
    AudioSource audio;
    Rigidbody rigidbody;
    bool isGround = true;
    float mouseX = 0;
    float mouseY = 0;
    Animator anim;
    bool isRunning = true;
    public EnermyController enermyController;
    bool Esc_keyDown = false; //Esc키가 눌린값을 담는 변수
    
   

    // Start is called before the first frame update
    void Start()
    {
        //playerAlive = true;
        tr = GetComponent<Transform>();
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive == true)
        {
            Walk();
            Turn();
            Jump();
        }
        
        PanelActive();
        
    }
    private void Walk()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (!isRunning)
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; //좌우이동
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed; //앞뒤이동
            tr.Translate(x, 0, z);
        }
        else
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed * 1.5f; //좌우이동
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed * 1.5f; //앞뒤이동
            tr.Translate(x, 0, z);
        }
    }
    private void Turn()
    {
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * 20.0f;
        mouseY += Input.GetAxis("Mouse Y") * Time.deltaTime * 10.0f;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        //Mathf.Clamp(현재위치, 제한하는 최소값, 최대값) : 회전 제한 주기위한
        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0); //rotate방식 적용X
        
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGround == true) //플레이어가 땅에 있어야 점프가능
            {
                rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse); 
                isGround = false;
            }
        }

    }


    void PanelActive()
    {
        if (playerAlive == false || Input.GetKeyDown(KeyCode.Escape) && Esc_keyDown == false) //살아있지 않다면 판넬이 나오게 설정
        {                                                                                     //Esc키가 눌리고 이미한번 한번 눌린 상태가 아니라면 나타나게설정
            panel.SetActive(true);
            Esc_keyDown = true;                                                               //Esc눌린걸 true로만들어주고
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Esc_keyDown == true)                      //위의 조건문을 실행 할수 없고, Esc키를 누르고 Esc_keyDown이 true 라면
        {
            panel.SetActive(false);                                                           //판넬없어지고
            Esc_keyDown = false;                                                              //Esc가 다시 안눌린 상태로 돌아가서 , 또 다시 누르게 되면 위의 조건문이 발동가능하게 설정
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enermy") //플레이어가 적에게 닿으면 죽음
        {
            playerAlive = false;
            PlayerDie();
        }
        
        if(collision.collider.tag == "ground") //플레이어가 땅에 닿아있는지 확인
        {
            isGround = true;
        }
        
    }
    
    void PlayerDie()
    {
        audio.Play();
        Time.timeScale = 0;
    }
     

}
