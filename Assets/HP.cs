using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UIを使うときに書きます。

public class HP: MonoBehaviour
{
    // 最大HPと現在のHP。
    int maxHp = 100;
    int Hp;
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

    // Start is called before the first frame update
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
        if (collider.gameObject.tag == "Trash")
        {
            Hp -= 10;
        }
        // Fishプレハブに接触したとき +10HP回復
        else if (collider.gameObject.tag == "Fish")
        {
            Hp += 10;
            if (Hp > maxHp) // 最大HPを超えないようにする
            {
                Hp = maxHp;
            }
        }
        // HPをSliderに反映。
        slider.value = (float)Hp;

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
