using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject eff_Boom;
   
    // Start is called before the first frame update

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 15000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnCollisionEnter(Collision collision) //파티클 효과 주고 싶지만 아직 더 공부해야됨
    {
        if(collision.collider.tag == "enermy")
        {
            GameObject obj = Instantiate(eff_Boom, collision.transform.position, Quaternion.identity);
            Destroy(obj, 1.0f);


        }
    }*/



}
