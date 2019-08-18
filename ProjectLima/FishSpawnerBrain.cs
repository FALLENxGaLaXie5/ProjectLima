using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerBrain : MonoBehaviour
{
    // Start is called before the first frame update
    public float minTime = 1;
    public float maxTime = 4;

    float spawnTime = 0;

    public GameObject topLeftBoundary, topRightBoundary, bottomLeftBoundary, bottomRightBoundary;

    public GameObject fishPrefab;

    GameObject[,] boundaries;

    void Start()
    {
        spawnTime = Time.deltaTime + Random.Range(minTime, maxTime);
        boundaries = new GameObject[,]
        {
            { topLeftBoundary, bottomLeftBoundary },
            {topRightBoundary, bottomRightBoundary }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime > spawnTime)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        int sideOfScreen = Random.Range(0, 2);
        float transformY = Random.Range(boundaries[sideOfScreen, 0].transform.position.y, boundaries[sideOfScreen, 1].transform.position.y);
        Debug.Log(boundaries[sideOfScreen, 0].transform.position.x);
        GameObject newFish = (GameObject)Instantiate(fishPrefab, new Vector2(boundaries[sideOfScreen, 0].transform.position.x, transformY), transform.rotation);
        Debug.Log("222");
        newFish.GetComponent<FishBrain>().SetDestination(new Vector2(sideOfScreen == 1 ? topLeftBoundary.transform.position.x : topRightBoundary.transform.position.x, transformY));
    }
}
