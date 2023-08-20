using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("Coins").ToString();
    }
}
