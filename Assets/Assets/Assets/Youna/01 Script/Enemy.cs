using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 Ai 만들기
// 1.자동으로 왼쪽으로 일정한 속도로 이동하게 한다.     -> Code 확인
// 2. J object와 Player가 땅에 존재할때만 적이 존재하다(맵 디자인)
// 3. Player가 일정거리로 다가왔을떄 이동한다          -> code 확인
// 4. Player와 충돌했을때 사라진다.                   -> code 확인
// 5. 혹은 카메라밖으로 일정 거리 나갔을 때 사라진다.   -> code 확인

public class Enemy : MonoBehaviour {

    public float speed = 4.0f;      // Enemy의 이동 속도
    public float dis = 0;         // Player를 인식하는 거리
    public bool isEnemy = false;

    int count = 0;

    Vector3 direction;
    GameObject target;

	void Start () {
        target = GameObject.Find("Player");     // Player를 찾는 동적할당
	}

    void Update()
    {
        dis = Vector3.Distance(target.transform.position, transform.position);           // Player와 적의 거리 계산
        if (dis <= 15f) /// Player와 적이 서로 일정거리에 들어간다면
        {
            // 거리가 10이하일때에만 계속해서 함수가 호출된다. 그렇지 않으면 함수는 호출되지 않는다.
            //gameObject.SetActive(true);
            isEnemy = true;     // Enemy는 활성화가 된다.
            count++;
            Enemygoto();
        }
        else if(dis >= 25)
        {
            isEnemy = false;
            Enemydestroy();
        }
    }

    void Enemygoto()    // enemy가 움직이는 함수
    {
        if (isEnemy)
        {
            // 적은 왼쪽으로 이동한다.
            transform.position += -(Vector3.right) * speed * Time.deltaTime;
        }
    }

    void Enemydestroy()
    {
        if (count == 0)
        { 
            //gameObject.SetActive(false);
        }//cout사용해보기
        else
        {
            print("사라져야함.");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)      // 충돌 계산
    {
        // 만일 플레이어와 부딪친다면, 플레이어의 체력은 깍이고 적은 사라진다.
        if (other.gameObject == target)
        {
            Debug.Log(other);
            // Player의 체력이 깍임.
            PlayerHP.Instance._hp--;
            // Enemy는 부딪치면 사라짐.
            Destroy(gameObject);
        }
    }
}
