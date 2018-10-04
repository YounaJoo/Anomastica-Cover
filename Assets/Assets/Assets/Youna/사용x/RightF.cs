using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모 오브젝트를 받아온다. 
// 오른쪽 놈이 플레이어랑 부딪히면 부모의 x축 막는것을 푼다
public class RightF : MonoBehaviour {

    Rigidbody p_rb;

	void Start () {
        p_rb = GetComponentInParent<Rigidbody>(); // 부모의 rigidbody 컴포넌트를 받아온다.
        Debug.Log(p_rb);
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        print(1);
        if (other.gameObject.tag == "Player")
        {
            // Player랑 부딪히면 부모의 x축 막는 것을 푼다.
            Debug.Log(other.gameObject);
            p_rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
