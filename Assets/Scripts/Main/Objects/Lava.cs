using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameMaster.Instance.Die(Mathf.Floor(GameObject.FindGameObjectWithTag("Player").transform.position.x));
    }
}
