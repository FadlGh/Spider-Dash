using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private TMP_Text text;

    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>().ShakeIt();
        int score = int.Parse(text.text);
        score++;

        text.text = score.ToString();

        Destroy(gameObject);
    }
}
