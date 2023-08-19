using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public GameObject corridorPrefab;
    public Transform playerTransform;
    public float corridorWidth;

    private float spawnX = -24f;

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject corridorSection = Instantiate(corridorPrefab, transform);
            corridorSection.transform.position = new Vector3(spawnX, 0f, 0f);

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
        GameObject corridorSection = Instantiate(corridorPrefab, transform);
        corridorSection.transform.position = new Vector3(spawnX, 0f, 0f);

        spawnX += corridorWidth;
    }
}