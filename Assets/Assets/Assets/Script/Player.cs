using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 이동속도
    public float speed = 5;
    // 점프속도
    public float jumpPower = 7;
    public bool isGrounded = false;
    Rigidbody rb;

    Vector3 movement;
    float horizontalMove;
    bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)

    {

        if (col.gameObject.tag == "Ground")

            isGrounded = true;  //Ground에 닿으면 isGround는 true

    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))   //입력키가 위화살표면 실행함
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse); // 점프
                isGrounded = false; //점프하면 isGrounded가 false
            }
        }

        Run();


    }

    void Run ()
    {
        movement.Set(horizontalMove, 0, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

}