using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player를 따라가는 카메라

public class MainCamera : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    private Vector3 position;

    public float downY = 1.5f; // camera y축 고정
    public float upY = 5.3f;
    public float skyY = 12;

    public bool isEarthquake = false;

    float earthX1 = 185;
    float earthX2 = 200;
    public float yvalue = 0;
    public float xvalue = 0;

    MeshRenderer BG;

    public GameObject ad;
    //Material mat;
    public Material[] matFactory;
    // 만일 Player가 하늘 위로 간다면 Camera Y 축 다른 쪽으로 고정시키고 바닥으로 내려가면 다시 위쪽 y고정 값으로 돌아간다.

    void Start () {
        offset = transform.position - player.transform.position;
        BG = GameObject.Find("Background").gameObject.GetComponent<MeshRenderer>();
//        mat = BG.material; // 인스턴스로 바꿈.
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            BG.material = matFactory[1];
        }

        position = player.transform.position + offset;
        if (player.transform.position.y < upY)
        {
            //position = player.transform.position + offset;
            Vector3 dir = new Vector3(position.x, downY, position.z);
            // transform.position = Vector3.Lerp(transform.position, dir, 5 * Time.deltaTime);
            transform.position = dir;

            // 동굴 속 이라면 이미지 변경 하고 아니라면 원래의 이미지로 사용한다
            // x축 55~142
            if (player.transform.position.x > 55 && player.transform.position.x < 142)
            {
                BG.material = matFactory[2];
            }
            else
            {
                BG.material = matFactory[0];
            }
        }
        else if(player.transform.position.y > upY & player.transform.position.y < skyY)
        {
            // Y의 위치는 upY로 고정
            Vector3 dir = new Vector3(position.x, upY+1f, position.z);
            transform.position = dir;
            // Y축위로 올라가면 배경 이미지 변경
            BG.material = matFactory[1];
        }
        else 
        {
            // Y의 위치는 skyY로 고정
            Vector3 dir = new Vector3(position.x, skyY + .5f, position.z);
            transform.position = dir;
        }

        // 흔들리는 효과 연출
        if (transform.position.x > earthX1 & transform.position.x < earthX2)
        {
            isEarthquake = true;
            ad.SetActive(true);
            transform.eulerAngles = new Vector3(xvalue, yvalue, 0) * 5 * Time.deltaTime;
        }
        else
        {
            isEarthquake = false;
            ad.SetActive(false);
        }

        // x값, y값에 따라 Image값 변경하기
    }
}
