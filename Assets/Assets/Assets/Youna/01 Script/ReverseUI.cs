using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseUI : MonoBehaviour {

    Image image;

    //public bool istrue;

    public GameObject blast_B;

    public static ReverseUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start () {
        image = gameObject.GetComponent<Image>();
        if (image != null)
        {
            Debug.Log(image);
        }
        else
        {
            return;
        }
	}

    private void Update()
    {
        // istrue = YN_BlockDestroy.Instance.istrue_K;
    }

    public void SetAciveTrue()
    {
        //Debug.Log(image.gameObject.activeSelf);
        //if (istrue == true)
        //{
        //    image.enabled = true;
        //    // B Object setactive true
        //    blast_B.SetActive(true);
        //}
        //else
        //{
        //    return;
        //}
        image.enabled = true;
        // B Object setactive true
        blast_B.SetActive(true);
    }
}
