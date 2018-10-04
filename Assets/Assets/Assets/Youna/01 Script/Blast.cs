using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// blast 효과 주기
//  - 오른쪽으로 못 밀고 오로지 왼쪽으로만 밀 수 있게 한다
//  - 만약 B가 바닥과 충돌하게 되면, 각각 숫자들은 각자의 위치로 이동, T는 Word 좌표 위로 올라가고
//  - 단어들의 Tag는 Ground로 변경하게 된다.
//  -> 변경 T의 Tag가 아닌 Word 사라짐

public class Blast : MonoBehaviour {

    public GameObject[] word; // -> 배열 사용해보기 0 : B, 1 : L, 2 : A, 3 : S, 4 : T, 5 : Word

    public bool isUp = false;   // up되었는지 확인하는 bool 함수 -> 얘가 true가 되면 단어들의 좌표가 변한다

    BoxCollider bc;

    Rigidbody rb;

    Vector3 b;

    private void Awake()
    {
        bc = GameObject.Find("Blast").gameObject.transform.GetComponent<BoxCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            // 각각 숫자들은 각자의 위치로 이동, T는 Word 좌표 위로 올라가고
            //  - 단어들의 Tag는 Ground로 변경하게 된다.
            b = transform.position;
            bc.enabled = false;
            WordMove();
        }
    }

    public void WordMove()
    {
        //Vector3 positionV = posi.transform.position;
        //word[0].transform.position = positionV;
        word[0].transform.position = new Vector3(b.x, 1.5f, b.z);
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        for (int i = 1; i < 5; i++)
        {
            Vector3 dir = word[i].transform.position;
            if (i % 2 == 0)
            {
                // 짝수 일땐 -2.3, +1.5, -1.2   /   0, 0, -80
                word[i].transform.position = new Vector3(dir.x, dir.y+3, dir.z);
                word[i].transform.Rotate(0, 0, -13);
            }
            else
            {
                // 홀수일떈 -3.2, +2, -1.2  /   0, 0, -103}
                word[i].transform.position = new Vector3(dir.x, dir.y + 3, dir.z);
                word[i].transform.Rotate(0, 0, +10);
            }
        }
        Destroy(word[5].gameObject);

    }
}
