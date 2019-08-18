﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerBrain : MonoBehaviour
{
    // Start is called before the first frame update
    public float minTime = 1;
    public float maxTime = 3;

    float spawnTime = 0, totalTime;

    public GameObject topLeftBoundary, topRightBoundary, bottomLeftBoundary, bottomRightBoundary;

    public GameObject fishPrefab;

    GameObject[,] boundaries;

    void Start()
    {
        spawnTime = totalTime + Random.Range(minTime, maxTime);
        boundaries = new GameObject[,]
        {
            { topLeftBoundary, bottomLeftBoundary },
            {topRightBoundary, bottomRightBoundary }
        };
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime > spawnTime)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        int sideOfScreen = Random.Range(0, 2);
        float transformY = Random.Range(boundaries[sideOfScreen, 0].transform.position.y, boundaries[sideOfScreen, 1].transform.position.y);
        Debug.Log("!");
        GameObject newFish = (GameObject)Instantiate(fishPrefab, new Vector2(boundaries[sideOfScreen, 0].transform.position.x, transformY), transform.rotation);
        Debug.Log("2");
        newFish.transform.Find("AI").GetComponent<FishBrain>().SetDirection(sideOfScreen == 0 ? new Vector2(1, 0) : new Vector2(-1, 0));
        spawnTime = totalTime + Random.Range(minTime, maxTime);
    }
}
