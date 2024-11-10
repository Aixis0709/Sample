using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 追加


public class Player : MonoBehaviour
{
    // 最大HPと現在のHP。
    int maxHp = 100;
    int Hp = 100;
    // Slider
    public Slider slider;
    // 時間経過によるダメージ関連
    private float timeSinceLastDamage = 0f;
    public float damageInterval = 1f; // 1秒ごとにダメージ
    // 当たり判定対象
    public GameObject Trash;
    public GameObject Fish;
    // ゲームオーバー関連
    public GameObject gameOverScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Sliderを最大にする。
        slider.maxValue = maxHp;
        slider.value = maxHp;
        // HPを最大HPと同じ値に。
        Hp = maxHp;
    }
    private void OnTriggerEnter(Collider collider)
    {
        // Trashプレハブに接触したとき -10ダメージ
        if (collider.gameObject.CompareTag("Trash"))
        {
            Debug.Log("hit trash");
            Hp = Hp - 10;
            slider.value = (float)Hp;
        }
        // Fishプレハブに接触したとき +10HP回復
        else if (collider.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Hit fish!");
            Hp = Hp + 10;
            if (Hp > maxHp) // 最大HPを超えないようにする
            {
                Hp = maxHp;
            }
            else
            {
                slider.value = (float)Hp;
            }
        }
        // HPをSliderに反映。

        // HPが0以下にならないようにする
        if (Hp <= 0)
        {
            Hp = 0;
            // ゲームオーバー処理などをここに追加
            gameOver();
        }
    }


    private void OnTriggerEnter2D(Collider2D item)
    {
        // Trashプレハブに接触したとき -10ダメージ
        if (item.gameObject.CompareTag("Trash"))
        {
            Debug.Log("hit trash");
            Hp = Hp - 10;
            slider.value = (float)Hp;
        }
        // Fishプレハブに接触したとき +10HP回復
        else if (item.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Hit fish!");
            Hp = Hp + 10;
            if (Hp > maxHp) // 最大HPを超えないようにする
            {
                Hp = maxHp;
            }
            else
            {
                slider.value = (float)Hp;
            }
        }
        // HPをSliderに反映。

        // HPが0以下にならないようにする
        if (Hp <= 0)
        {
            Hp = 0;
            // ゲームオーバー処理などをここに追加
            gameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 時間経過によるダメージ処理
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
