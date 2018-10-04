using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Turn 만약 BA가 존재한다면 -> position 전부 FIX
// 아니라면 FIX를 푼다.

// N이 Tur가 충돌이 되면 position은 FIX하고 모양은 Turn된다.
// Trun 되는게 카메라로 할까 아니면 Object들로 할까?

public class Turn : MonoBehaviour {

    public static float turnOn = 1;

    GameObject ba;
    GameObject tur;

    Rigidbody rb;

    bool isTurn = false;

    public GameObject maincamera;
    public GameObject[] test;
    public GameObject goal;
    GameObject heart;
    GameObject distance;
    GameObject background;
    GameObject player;
    float x = 0;
    float y = 0;
    float z = 900;
    public int width = 1024;
    public int height = 768;
    // public GameObject wait; // -> 얘는 Player에 붙여두자

    // 0119 UI는 안뒤집혀진다. 그렇다면 image하고 text는 UI로 하지말고 sprite로 바꾸자

    void Start () {
        ba = GameObject.Find("Extrude_ba");
        tur = GameObject.Find("Extrude_tur");
        rb = gameObject.GetComponent<Rigidbody>();
        heart = GameObject.Find("Heart");
        distance = GameObject.Find("Distance");
        background = GameObject.Find("Background");
        player = GameObject.Find("Player");
	}
	
	void Update () {
        if (ba != null)
        {
            // BA가 존재한다면 N의 POSITION들은 전부 FIX
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            // BA가 없다면 FIX를 푼다
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
	}
    private void OnCollisionEnter(Collision other)
    {
        // N이 Tur가 충돌이 되면 position은 FIX하고 모양은 Turn된다.
        if (other.gameObject == tur)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            print("부딪쳤땅");
            isTurn = true;
            RotateScene();
            //RotatePlayer();
        }
    }

    private void RotatePlayer()
    {
        // Player회전하고, Player의 Velocty값 변경
        Vector3 dir = new Vector3(x, y, z);
        player.transform.Rotate(dir * Time.deltaTime * 5);
        // Player의 Gravity값 변경
        //Physics.gravity = new Vector3(+9.8f, 0, 0);
    }

    private void RotateScene()
    {
        if (!isTurn)
        {
            return;
        }
        else
        {
            // 카메라 회전
            Vector3 dir = new Vector3(x, y, z);
            print(dir);
            maincamera.transform.Rotate(dir * Time.deltaTime * 5);
            // Screen.SetResolution(Screen.height, Screen.width, false); // 해상도 뒤집는거 

            // 부수적인 놈들도 뒤집기
            //heart.transform.Rotate(dir * Time.deltaTime * 5);
            //distance.transform.Rotate(dir * Time.deltaTime * 5);
            background.transform.Rotate(new Vector3(x, y, -900) * Time.deltaTime * 5);

            // 부수적인 놈들 위치 바꾸기
            heart.transform.position = test[0].transform.position;
            distance.transform.position = test[1].transform.position;

            // Reverse 중지시키기
            Image img = GameObject.Find("Reverse").gameObject.transform.GetComponent<Image>();
            Debug.Log(img);
            img.enabled = false;
            goal.SetActive(true);
            // 할 수 있다면 플레이어의 입력값도 바꾸기

            // 나경's
            //rb.useGravity = false;
        }
    }
}
