using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_BlockFall : MonoBehaviour {

    public float speed = 0.5f; // 구름의 상승 속도
    public int isFalling = 0; // 초기값은 0
    Vector3 pos; // 구름의 원래 위치
    Vector2 nowpos; // 구름의 현재 위치
    // Use this for initialization
    void Start () {
        pos = this.gameObject.transform.position; // 구름의 원래 위치값 저장
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            isFalling = 1;  //Player가 구름에 닿으면 isFalling는 1
        }
    }

    private void OnCollisionExit(Collision col)
    {
        isFalling = 2;  //충돌하지 않고 있으면 isFalling는 2
    }

    // Update is called once per frame
    void Update () {
        Vector3 nowpos = this.gameObject.transform.position; // 구름의 현재 위치값 저장
        if (isFalling==2)
        {
            if(pos.y > nowpos.y) // 구름의 현재 y좌표가 원래 y좌표보다 작을 때만 위로 상승
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else
            {
                isFalling = 0; // 아닐때는 isFalling을 0으로 초기화하여 정지
            }
        }
	}
}