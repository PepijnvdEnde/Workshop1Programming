using UnityEngine;

public class DrawSpeheres : MonoBehaviour
{
    public GameObject spherePrefab; // Assign a sphere prefab in the Inspector
    public int sphereCount = 10000;
    public float spawnRadius = 100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSpheres();
        }
    }

    void SpawnSpheres()
    {
        for (int i = 0; i < sphereCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius)
            );

            Instantiate(spherePrefab, randomPos, Quaternion.identity);
        }
    }

}
