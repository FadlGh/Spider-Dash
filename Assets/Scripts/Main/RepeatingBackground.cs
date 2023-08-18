using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private float spawnDistance = 10.0f;
    [SerializeField] private int maxBackgrounds = 3;

    private Transform player;
    private float lastSpawnPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastSpawnPosition = player.position.x;
        SpawnBackground(player.position.x);
    }

    private void Update()
    {
        float playerPositionX = player.position.x + 5f;

        if (playerPositionX - lastSpawnPosition >= spawnDistance)
        {
            SpawnBackground(playerPositionX);
        }

        BackgroundDeletion(playerPositionX);
    }

    private void SpawnBackground(float playerPositionX)
    {
        GameObject newBackground = Instantiate(backgroundPrefab, transform);
        float newX = playerPositionX + spawnDistance;
        newBackground.transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        lastSpawnPosition = playerPositionX;
    }

    private void BackgroundDeletion(float playerPositionX)
    {
        foreach (Transform child in transform)
        {
            if (child.position.x < playerPositionX - spawnDistance * maxBackgrounds)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
