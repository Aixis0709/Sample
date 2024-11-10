using UnityEngine;
using UnityEngine.Rendering;

public class Bear : MonoBehaviour
{
    public Rigidbody2D myrigibody;
    public float moveSpeed;
    public Logic Logic;
    public float moveRight = 10;
    public float Check = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            myrigibody.linearVelocity = Vector2.up * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            myrigibody.linearVelocity = Vector2.down * moveSpeed;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            Stop();
        }
        // checkinng with the team for engding goal
        float i = Logic.playerScore;
        bool moveRate = false;
        if (i >= Check)
        {
                myrigibody.linearVelocity = Vector2.right * moveRight;
                Check = Check + 5;
        }
        else
        {
            myrigibody.linearVelocity = Vector2.right * 0;
        }

    }
    void Stop()
    {
        myrigibody.linearVelocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("Trash"))
        {
            Debug.Log("Trash Deleted");
            Destroy(item.gameObject);
            Logic.addScore(-1);
        }
        else if (item.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Fish Deleted");
            Destroy(item.gameObject);
            Logic.addScore(1);

        }
    }

}