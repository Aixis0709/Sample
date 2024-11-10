using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI���g���Ƃ��ɏ����܂��B

public class HP: MonoBehaviour
{
    // �ő�HP�ƌ��݂�HP�B
    int maxHp = 100;
    int Hp;
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

    // Start is called before the first frame update
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
        if (collider.gameObject.tag == "Trash")
        {
            Hp -= 10;
        }
        // Fish�v���n�u�ɐڐG�����Ƃ� +10HP��
        else if (collider.gameObject.tag == "Fish")
        {
            Hp += 10;
            if (Hp > maxHp) // �ő�HP�𒴂��Ȃ��悤�ɂ���
            {
                Hp = maxHp;
            }
        }
        // HP��Slider�ɔ��f�B
        slider.value = (float)Hp;

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
