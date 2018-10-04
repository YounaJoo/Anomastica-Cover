using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// damage check하는 UI script
// 1. 화면을 깜빡이는 효과 연출
// 2. Player의 HP깍임
// 3. Heart UI의 Image change
// 4. 플레이어가 죽으면 화면이 흔들면서 효과 연출 하고, GameOver뜨며 개인랭킹이 뜬다

public class DamageCheck : MonoBehaviour {

    public GameObject damageUI;
    public int playerHP = 3;
    public float effectTime = .5f;
    public static DamageCheck instanceHP = null;
    int _hp;

    // 화면 흔들기
    public float camShakeTime = 1;
    float currentTime = 0;
    private Vector3 localPosition;

    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            StartCoroutine(DamageProcess());
        }
    }

    private void Awake()
    {
        if (instanceHP == null)
            instanceHP = this;
    }

    void Start () {
        _hp = playerHP;
	}
	
    // 코루틴 함수
    private IEnumerator DamageProcess()
    {
        // DamageUI를 켜라
        damageUI.SetActive(true);
        // UI를 보여주라
        yield return new WaitForSeconds(effectTime);
        // damageUI를 꺼라
        damageUI.SetActive(false);
        // hp가 하나씩 줄어들때마다, Image가 바뀐다.

        // hp 가 0보다 작으면
        //  - 화면을 일정시간 동안 흔들어주고
        //  - Gameover가 되며 개인랭킹이 뜬다.
    }
}
