using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletBar;
    public GameObject bullet;
    float prevT = 0.0f;
    int bulletNum = 30;
    public Text bulletCount;
    Animator anim;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Reload();
    }
    void Shoot()
    {
        if (Time.time > prevT + 0.1f)//Time.time은 계속흐르는 시간이자 시작하면 0.0부터 흐르는시간이다
        {
            if (Input.GetMouseButton(0) && GameObject.Find("Player").GetComponent<PlayerController>().playerAlive == true && bulletNum > 0)//살아 있을때만 총알 나가게
            {
                GameObject obj = Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                GameObject.Find("ShootSound").GetComponent<AudioSource>().Play();
                bulletNum--;
                bulletBar.GetComponent<Image>().fillAmount -= 0.033f; //탄창UI부분
                Destroy(obj, 2.0f);
                prevT = Time.time;

            }
            if (bulletNum == 0)
            {
                StartCoroutine(FillBullet());//시간지연 표현방식
            }
        }

        bulletCount.text = bulletNum.ToString() + " / 30" ; //남은 총알 갯수텍스트

    }
    void Reload()
    {
        if (Input.GetKey(KeyCode.R) && bulletNum<30)
        {
            StartCoroutine(FillBullet());
        }
    }


    IEnumerator FillBullet()//메서드만들고 수정
    {
        GameObject.Find("ReloadSound").GetComponent<AudioSource>().Play(); //총알이 0이된 상태로 Fillbullet 메소드 실행시 사운드 딜레이 발생
        anim.SetBool("Reload", true);        
        yield return new WaitForSeconds(2.2f);//필수적으로 써야됨(재장전후 일정시간 총알이 나가긴하는데 줄진않는 오류발생)
        bulletNum = 30; //총알 원상복구
        bulletBar.GetComponent<Image>().fillAmount = 1.0f;//탄창UI 원상복구
        anim.SetBool("Reload", false);
    }

}
