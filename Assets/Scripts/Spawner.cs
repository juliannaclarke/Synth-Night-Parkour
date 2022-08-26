using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    float minSpawnTime = 1.3f;
    public GameObject item;
    int floating;

    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            Vector3 position = Vector3.zero;
            position.x = 10.2f;

            if (item.tag == "PowerUp")
            {
                floating = Random.Range(0, 2);

                if (floating == 1)
                {
                    position.y = 0.44f;
                }
                else
                {
                    position.y = -1.65f;
                }
            }
            else
            {
                floating = Random.Range(0, 3);

                if (floating == 1)
                {
                    position.y = 0f;
                }
                else
                {
                    position.y = -1.4f;
                }
            }

            position.z = 1;
            Instantiate(item, position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
