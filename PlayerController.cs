using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public bool isOnGround = true;
    public float jumpForce;
    private Rigidbody rb;
    public GameObject PelletPrefab;
    public float numberOfPellets = 0;
    public float projectileSpeed = 10f;
    public Transform Player;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
         // Left & right input
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(0f, 0f, horizontalInput); 
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movement.z * speed); 

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);  
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); 
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            rb.drag = 0;
            speed = 15.0f;
        }

        //pellet firing
        if (Input.GetKeyDown(KeyCode.Z) && numberOfPellets > 0)
        {
            GameObject eggProjectile = Instantiate(PelletPrefab, Player.position, Player.rotation);
            
            eggProjectile.transform.parent = transform;
            
            Rigidbody projectileRigidbody = eggProjectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = -transform.up * projectileSpeed;

            numberOfPellets--;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }

        if(collision.gameObject.CompareTag("Cement"))
        {
            Player.transform.position = new Vector3(-2f, 6f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slingshot"))
        {
            numberOfPellets += 20;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("trash"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag ("grass1"))
        {
            SceneManager.LoadScene(5);
        }

        if (other.CompareTag ("grass2"))
        {
            SceneManager.LoadScene(6);
        }
    }
}
