using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlay : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Destroy(gameObject);
    }
}
