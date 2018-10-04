using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player랑 충돌이 일어났을떄,
// 이 모형이 구름 임팩트를 주게 한다(y축 이동)
// 충돌이 없을떄에는 천천~히 제자리로 돌아간다.

public class Cloud : MonoBehaviour {

    public float cloudSpeed = 0.01f;
    GameObject player;
    Vector3 currentDir;
    float yVelocity;
	
	void Start () {
        player = GameObject.Find("Player");
        currentDir = transform.position;
        yVelocity = currentDir.y - 2;
	}
	
	
	void Update () {
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            //transform.position = new Vector3(currentDir.x, yVelocity, currentDir.z) * cloudSpeed * Time.deltaTime;
            //print(new Vector3(currentDir.x, yVelocity, currentDir.z));
            //print(transform.position);
            //if (gameObject.transform.position.y > 0.3f)
            //{
            //    StartCoroutine(TestCoroutine());
            //}
            StartCoroutine(TestCoroutine());
        }
        else // 그게 아니라면
        {
            // 제자리로 돌아가라
            print("뿅");
        }
    }

    private IEnumerator TestCoroutine()
    {
        Vector3 dir = new Vector3(currentDir.x, currentDir.y - 3f, currentDir.z);
        for (int i = 0; i < 3; i++)
        {
            print(i);
            yield return new WaitForSeconds(0.3f);
            transform.position = Vector3.Lerp(transform.position, dir, 0.5f * Time.deltaTime);
        }
    }
}
