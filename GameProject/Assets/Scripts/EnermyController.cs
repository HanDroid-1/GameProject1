using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnermyController : MonoBehaviour
{
    public Image HPbar;
    Animator anim;
    NavMeshAgent agent;
    public bool EnermyAlive = true;
    public Transform tf_Destination;
   


    // Start is called before the first frame update
    void Start()
    {
        
        
        EnermyAlive = true;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
        
    }

    // Update is called once per frame
    void Update()
    { 
            EnermyMove();   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "bullet") //bullet 과 enermy가 닿았을때
        {
            HPbar.fillAmount -= 0.25f;
            Destroy(collision.gameObject);//총알파괴
            if (HPbar.fillAmount == 0)
            {

                CountScore.score++;                        //Enermy클래스 안에서 변수를 만들고 스코어 1추가를 했더니
                                                           //적들을 죽일때마다 숫자가 더해지는것이 아니라 문자인 1이 생겼다가 오브젝트가 파괴되니
                agent.isStopped = true;
                agent.velocity = Vector3.zero;             //Enermy가 죽고나면 미끄러짐현상해결
                EnermyAlive = false;                       //다시 0으로 변하는게 반복이 되는 문제를 Text에 스크립트를 따로 주고 연결하니 해결됨
                anim.SetBool("isDie", true);
                Destroy(gameObject,1.0f);                  //hp 0 되면 해당게임오브젝트 파괴
                
                GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
                //Enermy가 죽고도 콜라이더가 인식이 돼 스코어가 올라가는오류 수정
                //발동 조건문에 &&EnermyAlive == true 로 해봤지만 오류발생
            }
            //EnermyAlive = true;
          

        }
        
    }
    void EnermyMove()
    {
       Vector3 obj = GameObject.Find("Player").transform.position;
       agent.SetDestination(obj);//목적지 위치 플레이어의 위치로 설정(GameObject로 받아와서 하니까 프리팹화되어 랜덤생성되는 Enermy들에게는 적용이되지않아서
                                 //플레이어의 위치값을 Vector3 로 저장해서 찾아옴
    }
    
}
