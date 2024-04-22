using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cooldown());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == ("Player"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
