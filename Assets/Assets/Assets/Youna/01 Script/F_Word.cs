using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flower를 setActive하는 놈
// F의 Rotation은 Fix한다 -> 못하겠다.
// - 얘가 Map과 충돌하면, Flower는 SetActive한다

public class F_Word : MonoBehaviour {

    // rigidbody 를 사용하지 않고 -0.8 까지 y축이 이동하는걸로 하자. 
    public GameObject flower;
    GameObject map;
    bool activeFlower;

    Rigidbody rb;

    // box의 RayCast를 집어넣자
    // -> 오른쪽으로 조금 쏴서 Player가 있으면 x축 막는 것을 푼다.
    Ray ray;
    RaycastHit hitInfo;

    AudioSource ad;

    void Start () {
        map = GameObject.Find("Map");
        //activeFlower = flower.activeSelf;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
        ad = gameObject.GetComponent<AudioSource>();
    }

    // box의 RayCast를 집어넣자
    // -> 오른쪽으로 조금 쏴서 Player가 있으면 x축 막는 것을 푼다.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == map)
        {
            // 만약 flower가 active되어있다면 pass unactive가 되어있다면 active시킴
            if (!activeFlower)
            {
                flower.SetActive(true);
            }
            ad.Play();
        }
        if (other.gameObject.tag == "Player")
        {
            ray = new Ray(transform.position, -(transform.right));
            Debug.DrawRay(transform.position, -(transform.right) * 5, Color.red); 
            if (Physics.Raycast(ray, out hitInfo, 5.5f))
            {
                print("x축 봉쇄 푼다~");
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                print("X축 FIx~");
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX; // x축 Position 을 fix함
            }
        }
    }
}
