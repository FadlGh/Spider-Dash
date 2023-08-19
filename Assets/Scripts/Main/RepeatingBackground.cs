using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    [SerializeField] private GameObject corridorPrefab;
    [SerializeField] private GameObject[] coins;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float corridorWidth;

    private float spawnX = -24f;
    private int roomID;

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject corridorSection = Instantiate(corridorPrefab, transform);
            corridorSection.transform.position = new Vector3(spawnX, -0.79f, 0f);

            spawnX += corridorWidth;
        }
    }

    private void Update()
    {
        if (playerTransform.position.x > spawnX - 3 * corridorWidth)
        {
            SpawnCorridorSection();
        }
    }

    private void SpawnCorridorSection()
    {
        roomID++;
        GameObject corridorSection = Instantiate(corridorPrefab, transform);
        corridorSection.transform.position = new Vector3(spawnX, -0.79f, 0f);

        if (roomID % 3 == 0)
        {
            Instantiate(coins[Random.Range(0, coins.Length)], corridorSection.transform.position, Quaternion.identity);
        }

        spawnX += corridorWidth;
    }
}