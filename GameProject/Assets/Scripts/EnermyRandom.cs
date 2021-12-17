using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyRandom : MonoBehaviour
{
    public GameObject[] prefabs;//생성될 오브젝트를 배열로 넣어줌 (다양한 적 생성 위해)

    private BoxCollider area;
    public int count = 100;

    private List<GameObject> gameObject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>(); // 랜덤하게 만들 오브젝트들의 위치 범위를 제한하기위해불러줌 (size를받아오기위해서)
       for(int i = 0; i< count; i++)
        {
            Spawn();
        }
        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }



}
