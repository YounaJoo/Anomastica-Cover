using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 추가사항 : 아래로 Ray를 쏴서 충돌체 검사 후 닿는게 있는지 체크 -> 1순위

public class Youna_P : MonoBehaviour
{
    // 이동속도
    public float speed = 5;
    // 점프속도
    public float jumpPower = 10;
    public bool isGrounded = false;
    Rigidbody rb;
    BoxCollider bc;
    Vector3 movement;
    float horizontalMove;

    bool isJumping;

    // 추가사항1.
    Ray rayDOWN;
    Ray rayUP;
    RaycastHit hitInfo;
    public float count;

    // 추가사항2.
    // Turn 효과 주기
    //  - 인스턴스 필요. Turn 스크립트에서 CameraTurn과(이 스크립트에서 전부 해보기?) PlayerTrun 함수를 호출하면
    //  - Camera와 Player전부 z축으로 90도 회전시킨다. (Player속도가 Camera속도보다 느리게 변화시키기) -> 쿼터니언 사용?
    //  - Bool을 써서 isTurn 이 true가 되면 Gravity 끄고, yVelocity값 지정하기 -> update함수
    //  - 모든 함수가 끝나면 Wait은 꺼준다

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = transform.GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
            isGrounded = true;  //Ground에 닿으면 isGround는 true

    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        //Test();
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))   //입력키가 위화살표면 실행함
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse); // 점프
                isGrounded = false; //점프하면 isGrounded가 false

                // 함수로 처리해 보자.
                //Test();
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

        Run();
        Zoom();
    }

    void Zoom()
    {
        if (isGrounded == false)
        {
            Camera.main.orthographicSize = 2.8f;
        }
        else
        {
            Camera.main.orthographicSize = 3.3f;
        }
    }

    void Run ()
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
                print("1");
                bc.enabled = false;
            }
        }
    }

}