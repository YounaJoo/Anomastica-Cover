using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어의 거리를 나타나는 UI설정
// 플레이어가 이동한 거리를 UI text에 나타나게 한다.
// -> 인스턴스해서 동적할당하기.
// 인스턴스 성공 -> HP까지 여기서 설정하는게 어떨까??

public class Goal : MonoBehaviour {

    public static Goal instance;

    public TextMesh txt;

    GameObject goal;

    public float distance = 0;              // 거리 계산할 놈
    private float goalDistance;         // goal의 거리를 받아온다.
    private float startD = 0;
    private float currentDistance = 0.0f;   // 플레이어가 현재 이동하는 거리 위치.

    void Start () {
        txt = GameObject.FindObjectOfType<TextMesh>();
        goal = GameObject.Find("Goal");
        goalDistance = goal.transform.position.x;
        startD = -(transform.position.x);
        print(currentDistance);
	}
	
	void Update () {
        // 현재 이동한 거리
        currentDistance = startD + transform.position.x;
        // 목표거리에 따른 이동한 거리
        distance = goalDistance - (goalDistance - currentDistance);

        // 이동거리에 따른 text 변화
        txt.text = "이동거리 : " + distance.ToString("N2");

        // 만약 Player의 x축 위치가 목표의 x축 위치와 동일하다면 게임 종료
        // -> 게임 종료 씬? Image?생성
        if (currentDistance >= goalDistance)
        {
            print("GameSet");
        }
	}
}
