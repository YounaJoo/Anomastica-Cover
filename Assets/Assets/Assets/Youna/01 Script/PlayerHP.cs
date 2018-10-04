using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// player 의 HP를 설정하는 스크립트
public class PlayerHP : MonoBehaviour {

    int MAX_HP = 3;
    public int _hp;

    string i;

    public GameObject image;

    public SpriteRenderer sprite;

    public static PlayerHP Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        _hp = MAX_HP;
        sprite = image.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //if (_hp == 3)
        //{
        //    print("HP3이당~~");
        //    Debug.Log(image);
        //}
        //else if (_hp == 2)
        //{
        //    print("HP2이당~~");
        //    Debug.Log(image);
        //}
        //else if (_hp == 1)
        //{
        //    print("HP2이당~~");
        //    Debug.Log(image);
        //}
        //else if (_hp <= 0)
        //{
        //    print("죽어~~");
        //    Debug.Log(image);
        //}
        if (_hp >= 0)
        {
            i = _hp.ToString();
            HpSet();
        }
    }

    private void HpSet()
    {
        // Image 변경
        //image = Resources.Load<Sprite>(i);
        sprite.sprite = Resources.Load<Sprite>(i);
    }
}
