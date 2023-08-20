using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    private string distance;

    private void Start()
    {
        distance = Mathf.Floor(GameObject.FindGameObjectWithTag("Player").transform.position.x).ToString() + " m";
        GetComponent<TMP_Text>().text = distance;
    }

    void Update()
    {
        if (GameMaster.Instance.isDead) { return; }
        distance = Mathf.Floor(GameObject.FindGameObjectWithTag("Player").transform.position.x).ToString() + " m";
        GetComponent<TMP_Text>().text = distance;
    }
}
