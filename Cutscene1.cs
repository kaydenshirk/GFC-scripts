using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cutscene1 : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Mayor1;
    public GameObject Player2;
    public GameObject Mayor2;
    public GameObject Player3;
    public GameObject Mayor3;
    public GameObject Player4;
    public GameObject Mayor4;
    public float CutsceneInterval = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CutsceneInterval++;
        }
        if (CutsceneInterval < 1)
        {
            Player1.SetActive(true);
            Mayor1.SetActive(false);
        }
        if (CutsceneInterval > 0)
        {
            Player1.SetActive(false);
            Mayor1.SetActive(true);
            Player2.SetActive(false);
        }

        if (CutsceneInterval > 1)
        {
            Mayor1.SetActive(false);
            Player2.SetActive(true);
            Mayor2.SetActive(false);
        }

        if (CutsceneInterval > 2)
        {
            Mayor2.SetActive(true);
            Player2.SetActive(false);
            Player3.SetActive(false);
        }

        if(CutsceneInterval > 3)
        {
            Player3.SetActive(true);
            Mayor2.SetActive(false);
            Mayor3.SetActive(false);
        }

        if (CutsceneInterval > 4)
        {
            Mayor3.SetActive(true);
            Player3.SetActive(false);
            Player4.SetActive(false);
        }

        if(CutsceneInterval > 5)
        {
            Player4.SetActive(true);
            Mayor3.SetActive(false);
            Mayor4.SetActive(false);
        }

        if (CutsceneInterval > 6)
        {
            Player4.SetActive(false);
            Mayor4.SetActive(true);
        }

        if (CutsceneInterval > 7)
        {
            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CutsceneInterval--;
        }
    }
}
