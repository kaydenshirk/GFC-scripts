using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCulling : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            text1.SetActive(false);
            text2.SetActive(true);
        }

        if (timer > 20)
        {
            text2.SetActive(false);
            text3.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            timer = 0f;
            text1.SetActive(true);
            text2.SetActive(false);
            text3.SetActive(false);
        }
    }
}
