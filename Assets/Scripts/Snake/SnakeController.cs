using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public float snakeSpeed;
    
    private Rigidbody2D rb;

    private List<Transform> _snakeSpwan;
    public Transform snakPrefab;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(snakeSpeed, 0);


        _snakeSpwan = new List<Transform>();
        _snakeSpwan.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(0, snakeSpeed);
        }if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -snakeSpeed);
        }if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(snakeSpeed, 0);
        }if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-snakeSpeed, 0);
        }
    }
    void FixedUpdate()
    {
        for (int i = _snakeSpwan.Count-1; i > 0; i--)
        {
            _snakeSpwan[i].position = _snakeSpwan[i - 1].position;
        }
    }
    private void Grow()
    {
        Transform snakeSpown = Instantiate(this.snakPrefab);
        snakeSpown.position = _snakeSpwan[_snakeSpwan.Count - 1].position;

        _snakeSpwan.Add(snakeSpown);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Grow();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    public void StopPlayerMov()
    {
        snakeSpeed = 0;
        Debug.Log("MOOOO"); 
    }
}
