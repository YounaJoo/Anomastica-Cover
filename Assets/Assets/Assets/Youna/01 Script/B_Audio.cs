using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Audio : MonoBehaviour {
    public GameObject player;

    public GameObject extrude;

    public float distance = -2f;
    public bool istrue = false;

    public Vector3 dir;

    //AudioSource ad;

    void Start()
    {
        player = GameObject.Find("Player");
        //ad = gameObject.GetComponent<AudioSource>();
        if (extrude != null)
        {
            Debug.Log("Find Object!" + extrude);
        }
    }

    void Update()
    {
        // Player가 일정거리로 다가가면
        // 오브젝트 setActive true
        dir = player.transform.position - transform.position;
        if (dir.x <= distance)
        {
            istrue = false;
        }
        else
        {
            istrue = true;
            Activetrue();
        }
    }

    private void Activetrue()
    {
        if (istrue)
        {
            extrude.SetActive(true);
        }
        else
        {
            Debug.Log("어서 True로 만들어벌여!!");
        }
    }
}
