using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Awake되자마자 크기 키우기하자.
public class Flower : MonoBehaviour {

    Vector3 dir;

    public GameObject wait;

    private void Awake()
    {
        StartCoroutine(SizeupFlower());
        dir = transform.position;
    }
    void Start () {
        // Wait setActive하는 함수 불러오기	
        wait.SetActive(true);
	}
    // bool 타입을 써서, 처음은 이 bool 이 true로 해서 wait이 나오게 하고
    // 코루틴이 끝나면 bool은 false로 바꿔서 wait을 끄게 한다.
    IEnumerator SizeupFlower()
    {
        yield return new WaitForSeconds(1f);
        // 크기를 지정해서 각각 키우게 하자.
        transform.localScale += new Vector3(30f, 30f, 30f) * 0.5f * Time.deltaTime;
        print(transform.position);
        transform.position = new Vector3(dir.x, -1.5f, 0);

        yield return new WaitForSeconds(1f);
        transform.localScale += new Vector3(60f, 60f, 60f) * 0.5f * Time.deltaTime;
        //transform.position = new Vector3(-6.37f, 1.9f, 0);

        yield return new WaitForSeconds(1f);
        transform.localScale += new Vector3(80f, 80f, 80f) * 0.5f * Time.deltaTime;
        //transform.position = new Vector3(-6.37f, 3.6f, 0);

        // Wait setActive false 하는 함수 불러오기
        wait.SetActive(false);
    }
}
