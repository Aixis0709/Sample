using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Logic Logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("Trash"))
        {
            Debug.Log("Score add");
            Logic.addScore(1);
        }
    }
}
