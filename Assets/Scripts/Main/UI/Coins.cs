using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("Coins").ToString();
    }
}
