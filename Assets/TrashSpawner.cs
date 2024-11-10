using System.Diagnostics.Contracts;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject Trash;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTrash();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnTrash();
            timer = 0;
        }
    }
    void SpawnTrash()
    {
        float lowestpoint = transform.position.y - heightOffset;
        float highestpoint = transform.position.y + heightOffset;
        Instantiate(Trash, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }
}
