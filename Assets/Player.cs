using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // �ǉ�


public class Player : MonoBehaviour
{
    // �ő�HP�ƌ��݂�HP�B
    int maxHp = 100;
    int Hp = 100;
    // Slider
    public Slider slider;
    // ���Ԍo�߂ɂ��_���[�W�֘A
    private float timeSinceLastDamage = 0f;
    public float damageInterval = 1f; // 1�b���ƂɃ_���[�W
    // �����蔻��Ώ�
    public GameObject Trash;
    public GameObject Fish;
    // �Q�[���I�[�o�[�֘A
    public GameObject gameOverScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Slider���ő�ɂ���B
        slider.maxValue = maxHp;
        slider.value = maxHp;
        // HP���ő�HP�Ɠ����l�ɁB
        Hp = maxHp;
    }
    private void OnTriggerEnter(Collider collider)
    {
        // Trash�v���n�u�ɐڐG�����Ƃ� -10�_���[�W
        if (collider.gameObject.CompareTag("Trash"))
        {
            Debug.Log("hit trash");
            Hp = Hp - 10;
            slider.value = (float)Hp;
        }
        // Fish�v���n�u�ɐڐG�����Ƃ� +10HP��
        else if (collider.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Hit fish!");
            Hp = Hp + 10;
            if (Hp > maxHp) // �ő�HP�𒴂��Ȃ��悤�ɂ���
            {
                Hp = maxHp;
            }
            else
            {
                slider.value = (float)Hp;
            }
        }
        // HP��Slider�ɔ��f�B

        // HP��0�ȉ��ɂȂ�Ȃ��悤�ɂ���
        if (Hp <= 0)
        {
            Hp = 0;
            // �Q�[���I�[�o�[�����Ȃǂ������ɒǉ�
            gameOver();
        }
    }


    private void OnTriggerEnter2D(Collider2D item)
    {
        // Trash�v���n�u�ɐڐG�����Ƃ� -10�_���[�W
        if (item.gameObject.CompareTag("Trash"))
        {
            Debug.Log("hit trash");
            Hp = Hp - 10;
            slider.value = (float)Hp;
        }
        // Fish�v���n�u�ɐڐG�����Ƃ� +10HP��
        else if (item.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Hit fish!");
            Hp = Hp + 10;
            if (Hp > maxHp) // �ő�HP�𒴂��Ȃ��悤�ɂ���
            {
                Hp = maxHp;
            }
            else
            {
                slider.value = (float)Hp;
            }
        }
        // HP��Slider�ɔ��f�B

        // HP��0�ȉ��ɂȂ�Ȃ��悤�ɂ���
        if (Hp <= 0)
        {
            Hp = 0;
            // �Q�[���I�[�o�[�����Ȃǂ������ɒǉ�
            gameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԍo�߂ɂ��_���[�W����
        timeSinceLastDamage += Time.deltaTime;
        if (timeSinceLastDamage >= damageInterval)
        {
            Hp -= 1;
            if (Hp < 0)
            {
                Hp = 0;
            }
            slider.value = (float)Hp;
            timeSinceLastDamage = 0f;
        }
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
