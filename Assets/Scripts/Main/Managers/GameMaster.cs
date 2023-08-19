using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    void Start()
    {
        Time.timeScale = 1f;
        deathUI.SetActive(false);
        isDead = false;
        print(PlayerPrefs.GetFloat("HighScore"));
    }

    public void Die(float score)
    {
        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }

        Time.timeScale = 0.1f;
        isDead = true;

        deathUI.SetActive(true);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
