using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_BlockDestroy : MonoBehaviour {

    GameObject Player;
    int count = 0;

    void Start () {
        Player = GameObject.Find("Player");
    }
    // 다른 물체와 충돌했을 때 호출됨
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.relativeVelocity.magnitude > 5 & collision.gameObject == Player) // 다른 물체와의 충격량이 2보다 크면
        {
            print(count);
            count++; //카운트 증가

            if(count==1) // 1일때
            {
                transform.Rotate(0,0,-15);
            }
            else if(count==2) // 2일때
            {

                transform.Rotate(0, 0, -20);
            }
            else if(count==3) // 3일때
            {
                Destroy(gameObject); // 자기 자신 사라짐
                count = 0;
            }
            
        }
    }
}