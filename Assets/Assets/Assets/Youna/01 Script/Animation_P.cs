using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 추가사항 : 아래로 Ray를 쏴서 충돌체 검사 후 닿는게 있는지 체크 -> 1순위

public class Animation_P : MonoBehaviour
{
    // 이동속도
    public float speed = 5;
    // 점프속도
    public float jumpPower = 1;
    public bool isGrounded = false;
    Rigidbody rb;
    //BoxCollider bc;
    CapsuleCollider bc;
    Vector3 movement;
    Animator anim;
    public float verticalMove;
    public float horizontalMove;

    bool isJumping;

    // 추가사항1.
    Ray rayDOWN;
    Ray rayUP;
    RaycastHit hitInfo;
    public float count;

    public bool isWalk;

    public static Animation_P instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = transform.GetComponent<CapsuleCollider>();
        anim = gameObject.transform.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;  //Ground에 닿으면 isGround는 true// ground 수정해보기
            //anim.SetTrigger("Idle");
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (horizontalMove != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))   //입력키가 위화살표면 실행함
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse); // 점프
                isGrounded = false; //점프하면 isGrounded가 false
                Test2();
            }
        }

        if (bc.enabled == false)
        {
            print("뀨우우?");
            count += Time.deltaTime;
            // 시간으로 하지 말고,
            // 바닥에 Ray를 쐈을 때 바닥에 닿았을떄 true
            if (count > 1)
            {
                count = 0;
                bc.enabled = true;
            }
        }
        Walk();
        Zoom();
    }

    void Zoom()
    {
        if (isGrounded == false)
        {
            Camera.main.orthographicSize = 3.0f;
        }
        else
        {
            Camera.main.orthographicSize = 3.3f;
        }
    }

    private void NewRun()
    {
        movement.Set(0, verticalMove, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Walk ()
    {
        movement.Set(horizontalMove, 0, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Test2()
    {
        // 점프했을 떄 ray 를 위로 쐈을때, tag가 flower 이면 player의 collider 를 false하고
        // colider가 fasle일떄, 새롭게 레이를 아래로 쏴서 tag가 flower이면 player의 collider를 true해보자. -> update??
        rayUP = new Ray(transform.position, Vector3.up);
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        layerMask = ~layerMask;
        bool Up_ray = Physics.Raycast(rayUP, out hitInfo, 15, layerMask);
        rayDOWN = new Ray(transform.position, -(Vector3.up));
        bool Down_ray = Physics.Raycast(rayDOWN, out hitInfo, 15, layerMask);
        
        if (Up_ray | Down_ray)
        {
            if (hitInfo.transform.name.Contains("Leaf"))
            {
                //print("1");
                Debug.Log(rayDOWN);
                bc.enabled = false;
            }
        }
    }
}