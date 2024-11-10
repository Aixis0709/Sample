using UnityEngine;

public class Trash : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -50;

    public Logic Logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Object Deleted");
            Destroy(gameObject);
        }
    }
    

}
