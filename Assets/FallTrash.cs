using UnityEngine;
using System.Collections;

public class FallTrash : MonoBehaviour
{
    public GameObject trashPrefab; // 発生させるプレハブ
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 初期設定
        if (trashPrefab == null)
        {
            Debug.LogError("The trashPrefab has not been assigned in the inspector.");
        }
        else
        {
            StartCoroutine(SpawnTrashRoutine());
        }
    }
    IEnumerator SpawnTrashRoutine()
    {
        yield return new WaitForSeconds(3f); // ゲームスタート後3秒待機
        while (true)
        {
            float randomX = Random.Range(-15f, 50f); // x軸が-15から50の間でランダムな位置
            Vector3 spawnPosition = new Vector3(randomX, 8f, transform.position.z);

            // Trashオブジェクトを生成
            GameObject newTrash = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

            // Rigidbody2Dを追加して放物線を描くように設定
            Rigidbody2D rb = newTrash.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1.0f; // 標準の重力スケール

            // x軸-30、y軸-20に向かうように初速度を設定
            Vector2 target = new Vector2(-30f, -20f);
            Vector2 direction = (target - (Vector2)spawnPosition).normalized;
            float speed = 5f; // 速度を調整
            rb.linearVelocity = direction * speed;

            yield return new WaitForSeconds(3f); // 3秒間隔で生成
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
