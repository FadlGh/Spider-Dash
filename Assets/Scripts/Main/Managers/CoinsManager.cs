using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager Instance;

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

    public void EditCoins()
    {
        PlayerPrefs.SetFloat("Coins" , PlayerPrefs.GetFloat("Coins") + int.Parse(GetComponent<TMP_Text>().text));
    }
}
