using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    bool enableSpawn = true;
    public GameObject[] Enermy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnermy", 3, 5); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행
    }

    void SpawnEnermy()
    {
        if (enableSpawn) //적이 죽으면 생성되도록 조건 줄 예정
        {
            float randomX = Random.Range(-50.0f, 50.0f);//적이 나타날 X좌표를 랜덤 생성
            float randomZ = Random.Range(-50.0f, 50.0f);//적이 나타날 Y좌표를 랜덤 생성
            Vector3 spawnPos = new Vector3(randomX, 0.0f, randomZ);
            int EnermyIndex = Random.Range(0, Enermy.Length); //오브젝트 생성시 에너미 배열의 인덱스를 랜덤으로 지정 
            GameObject obj = Instantiate(Enermy[EnermyIndex],spawnPos, Quaternion.identity); //랜덤한 오브젝트를 랜덤한 위치에 생성
        }
    }
    
 
}
