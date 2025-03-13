using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Assign a sphere prefab with a collider and material in the Inspector
    public int maxSpheresPerSecond = 10; // Max spheres to spawn per second
    public float spawnInterval = 1.0f; // Spawn every second
    public Vector3 spawnAreaSize = new Vector3(20f, 30f, 20f); // Size of spawn area

    private float timer = 0f;

    void Start()
    {
        if (spherePrefab == null)
        {
            // Create a basic sphere if no prefab is assigned
            spherePrefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            spherePrefab.AddComponent<Rigidbody>();
            spherePrefab.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnSpheres();
            timer = 0f;
        }
    }

    void SpawnSpheres()
    {
        int numSpheres = Random.Range(1, maxSpheresPerSecond + 1);

        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x, spawnAreaSize.x),
                Random.Range(20f, 50f), // Between y=20 and y=50
                Random.Range(-spawnAreaSize.z, spawnAreaSize.z)
            );

            GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
            Rigidbody rb = newSphere.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = newSphere.AddComponent<Rigidbody>();
            }

            rb.useGravity = true;
        }
    }
}

