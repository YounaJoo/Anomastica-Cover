using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배경 스크롤 되게 하기 

public class Background : MonoBehaviour {

    MeshRenderer mr;
    Material mat;
    public float speed = .5f;
    Camera cm; // 부모 카메라

	void Start () {
        cm = gameObject.GetComponentInParent<Camera>(); // 부모 카메라 받아오기.
        mr = gameObject.GetComponent<MeshRenderer>();
        mat = mr.material;
        Debug.Log(cm.name);
	}
	
	void Update () {
        // Camera가 움직이는 속도를 누적해서 배경을 움직이게 하자.
        
        //mat.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
	}
}
