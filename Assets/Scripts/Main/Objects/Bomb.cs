using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameMaster.Instance.isDead)
            GameMaster.Instance.Die(Mathf.Floor(GameObject.FindGameObjectWithTag("Player").transform.position.x));
        Destroy(this.gameObject);

    }
}
