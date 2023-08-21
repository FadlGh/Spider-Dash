using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameObject deathUI;

    public static GameMaster Instance;
    public bool isDead;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerPrefs.SetFloat("Coins", 800f);
    }

    void Start()
    {
        Time.timeScale = 1f;
        deathUI.SetActive(false);
        isDead = false;
    }

    public void Die(float score)
    {
        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }

        CoinsManager.Instance.EditCoins();

        Time.timeScale = 0.1f;
        isDead = true;

        deathUI.SetActive(true);

        if (PlayerPrefs.GetFloat("Coins") <= 50)
        {
            GameObject.FindGameObjectWithTag("Continue").SetActive(false);
        }

        AudioManager.instance.Play("Die");

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>().ShakeIt();
    }

    public void Continue()
    {
        isDead = false;

        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 4f, 1.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        deathUI.SetActive(false);

        Time.timeScale = 1f;
        PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") - 50);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
