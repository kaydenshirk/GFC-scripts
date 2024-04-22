using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAi : MonoBehaviour
{
    public Transform Boss;
    public Transform target;
    public float BossHealth = 20.0f;
    public GameObject projectilePrefab;
    public int projectilesPerRound = 2;
    public float roundInterval = 6f;
    public float JumpInterval = 12f;
    public float spawnDelay = 0.2f; 
    public float startDelay = 5f;
    public bool isOnGround = true;
    public float speed = 20.0f;
    public float jumpForce;

    private float jumpTimer = 0f;
    private float timer = 0f;
    private bool spawning = false;
    private Rigidbody rb;

    void Start()
    {
        Boss = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StartDelayCoroutine());
    }

    void Update()
    {
        if (BossHealth < 1)
        {
            SceneManager.LoadScene(2);
        }

        timer += Time.deltaTime;
        jumpTimer += Time.deltaTime;

        if (!spawning && timer >= roundInterval)
        {
            StartCoroutine(SpawnProjectilesSequence());
            timer = 0f;
        }

        //jumping
        if (jumpTimer >= JumpInterval)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            speed = 15.0f;
            jumpTimer = 0f;
        }

        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float step = speed * Time.deltaTime;
            transform.Translate(direction.normalized * step, Space.World);
            RotateEnemy(direction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            BossHealth--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            speed = 5.0f;
        }
    }

    private void RotateEnemy(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    IEnumerator StartDelayCoroutine()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(SpawnProjectilesSequence());
    }

    IEnumerator SpawnProjectilesSequence()
    {
        spawning = true;
        int projectilesSpawned = 0;

        while (projectilesSpawned < projectilesPerRound)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(180f, 0f, 0f));
            projectilesSpawned++;
            yield return new WaitForSeconds(spawnDelay);
        }
        spawning = false;
    }
}
