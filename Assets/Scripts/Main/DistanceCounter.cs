using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMP_Text>().text = Mathf.Floor(GameObject.FindGameObjectWithTag("Player").transform.position.x).ToString() + " m";
    }
}
