using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    public FruitSO[] fruitPrefabs;
    public GameObject fruit_base_prefab;
    public GameObject bombPrefab;
    [Range(0f, 1f)] public float bombChance = 0.05f;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 22f;

    public float maxLifetime = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = fruit_base_prefab;
            bool bomba_ = false;
            if (Random.value < bombChance) {
                bomba_ = true;
                prefab = bombPrefab;
            }

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit = Instantiate(prefab, position, rotation);
            int random_ = Random.Range(0, fruitPrefabs.Length);
            if (bomba_ == false)
            {
                Material[] materiales = new Material[2];
                materiales[0] = fruitPrefabs[random_].material_outside;
                materiales[1] = fruitPrefabs[random_].material_inside;

                fruit.GetComponent<Fruit>().whole.GetComponent<Renderer>().material = materiales[0];

                fruit.GetComponent<Fruit>().sliced_bottom.GetComponent<Renderer>().materials = materiales;

                fruit.GetComponent<Fruit>().sliced_top.GetComponent<Renderer>().materials = materiales;
            }
            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
            bomba_ = false;
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

}
