using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YN_BlockDestroy : MonoBehaviour {

    GameObject Player;
    int count = 0;
    Vector3 dir;

    public AudioSource ad;

    public bool istrue_K = false;
    public static YN_BlockDestroy Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start () {
        Player = GameObject.Find("Player");
        dir = transform.position;
        ad = GameObject.Find("OLD").transform.gameObject.GetComponent<AudioSource>();
        Debug.Log(ad.name);
    }
	
    // 다른 물체와 충돌했을 때 호출됨
    public void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude > 5 & other.gameObject.tag == "Player") // 다른 물체와의 충격량이 2보다 크면
        {
            print(count);
            count++; //카운트 증가

            if(count==1) // 1일때
            {
                transform.position = new Vector3(dir.x + 0.3f, dir.y + 0.5f, dir.z);
                transform.Rotate(0, 0, -10);
                dir = transform.position;
                ad.Play();
            }
            else if(count==2) // 2일때
            {
                transform.position = new Vector3(dir.x - 0.8f, dir.y - 1.2f, dir.z);
                transform.Rotate(0, 0, +20);
                ad.Play();
            }
            else if(count==3) // 3일때
            {
                ad.Play();
                if (gameObject.name == "K_Extrude")
                {
                    // istrue_K = true;
                    ReverseUI.Instance.SetAciveTrue();
                    // UI 부분 건드는 부분을 받아와서 변경하기
                }
                Destroy(gameObject); // 자기 자신 사라짐
                count = 0;
            }
        }
    }
}