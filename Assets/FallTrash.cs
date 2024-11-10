using UnityEngine;
using System.Collections;

public class FallTrash : MonoBehaviour
{
    public GameObject trashPrefab; // ����������v���n�u
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �����ݒ�
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
        yield return new WaitForSeconds(3f); // �Q�[���X�^�[�g��3�b�ҋ@
        while (true)
        {
            float randomX = Random.Range(-15f, 50f); // x����-15����50�̊ԂŃ����_���Ȉʒu
            Vector3 spawnPosition = new Vector3(randomX, 8f, transform.position.z);

            // Trash�I�u�W�F�N�g�𐶐�
            GameObject newTrash = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

            // Rigidbody2D��ǉ����ĕ�������`���悤�ɐݒ�
            Rigidbody2D rb = newTrash.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1.0f; // �W���̏d�̓X�P�[��

            // x��-30�Ay��-20�Ɍ������悤�ɏ����x��ݒ�
            Vector2 target = new Vector2(-30f, -20f);
            Vector2 direction = (target - (Vector2)spawnPosition).normalized;
            float speed = 5f; // ���x�𒲐�
            rb.linearVelocity = direction * speed;

            yield return new WaitForSeconds(3f); // 3�b�Ԋu�Ő���
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
