using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    public GameObject Level1;
    public GameObject Credits;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Level1"))
                    {
                        SceneManager.LoadScene(1);
                    }
                    
                    if (hit.collider.CompareTag("Credits"))
                    {
                        SceneManager.LoadScene(3);
                    }

                    if (hit.collider.CompareTag("ReturnToTitle"))
                    {
                        SceneManager.LoadScene(0);
                    }
                }
            }

        }
    }
}
