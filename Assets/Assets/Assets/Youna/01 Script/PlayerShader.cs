using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아래로 Ray를 쏴서 충돌체 검사 후 닿는게 있는지 체크 -> (Flower잎들 check하기)

public class PlayerShader : MonoBehaviour {

    Ray ray;
    RaycastHit hitInfo;
    public GameObject test;

	void Start () {
        // 아래는 -up 근데 Vector3 up으로 한다면 절대방향(?)으로 가게 된다. -> 나는 이것을 pick 무조건 수직으로 향해야 하기 떄문이다.
        // Player기준으로 가게 할떄, transform.up으로 하면 Player기준이 된다
	}
	
	void Update () {
        // 만약에 점프하게 된다면, 그 점프한게 바닥이라면 
        // 상대방의 충돌체가 active된다.
        ray = new Ray(transform.position, -(Vector3.up));
        // Object들이 많다보니, Tag확인은 어떻게 해야할까?  
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.tag.Equals("Ground"))
            {
                BoxCollider bc = hitInfo.transform.GetComponent<BoxCollider>();
                Debug.Log(hitInfo.transform.name);
                bc.enabled = true;
                // Ray를 맞은놈의 Colider 컴포넌트는 어떻게 받아와야 할까?
                // 맞은놈의 콜라이더 컴포넌트 말고 플레이어의 컴포넌트를 받아와서 일을 처리하자.
            }
        }
	}
}
