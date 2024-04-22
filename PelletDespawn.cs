using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
