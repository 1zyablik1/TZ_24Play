using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject startPlatfrom;
    [Header("CollectableCube")]
    [SerializeField] private GameObject collectableCube;
    [SerializeField] private GameObject collectableCubeContainer;
    [Header("DeadlyCube")]
    [SerializeField] private GameObject deadlyCube;
    [SerializeField] private GameObject deadlyCubeContainer;
    [Header("Platform")]
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject platformContainer;

    private Pool collectableCubePool;
    private Pool deadlyCubePool;
    private Pool platformPool;


    private Platform lastPlatform;

    private float platformAnimateTime = 2f;
    private float backOffset = 15;
    private float roadLength = 30;
    private int roadSegmentsCounter;
    private int startCointSegments = 4;
    private int halfRoad = 2;

    private int CollectingCubeCount = 0;
    
    public List<GeneratePatterns> generatePatterns;

    private void Awake()
    {
        collectableCubePool = new Pool(collectableCube, collectableCubeContainer);
        deadlyCubePool = new Pool(deadlyCube, deadlyCubeContainer, 100);
        platformPool = new Pool(platform, platformContainer);

        GenerateStartPlatform();
    }

    private void Start()
    {
        GenerateOnReset();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnGameReset += GameReset;
        Events.OnPlatfromDelete += PlatformDeleted;
    }

    private void Unsubscribe()
    {
        Events.OnGameReset -= GameReset;
        Events.OnPlatfromDelete -= PlatformDeleted;
    }

    private void GameReset()
    {
        collectableCubePool.CleatPool();
        deadlyCubePool.CleatPool();
        platformPool.CleatPool();

        GenerateOnReset();
    }

    private void PlatformDeleted()
    {
        GenerateNewSegmentAnim();
    }

    private void GenerateOnReset()
    {
        roadSegmentsCounter = 1;

        for (; roadSegmentsCounter <= startCointSegments;)
        {
            GenerateNewSegment();
        }
    }

    private void GenerateStartPlatform()
    {
        Instantiate(startPlatfrom, new Vector3(0, 0, 0 - backOffset), Quaternion.identity);
    }

    private void GenerateNewSegment()
    {
        GenerateNewPlatform();
        GenerateCollectableCubes();
        GenerateDeadlyCubes();
    }

    private void GenerateNewSegmentAnim()
    {
        GenerateNewSegment();
        AnimatePlatform();
    }

    private void GenerateNewPlatform()
    { 
        lastPlatform = platformPool.GetFreeElement(new Vector3(0, 0, (roadLength * roadSegmentsCounter) - backOffset)).GetComponent<Platform>();
        roadSegmentsCounter++;
    }

    private void GenerateCollectableCubes()
    {
        CollectingCubeCount = 0;
        int spawnChance = 9;

        foreach(var spawn in lastPlatform.spawnCollectableCube)
        {

            if(Random.Range(0, 10) < spawnChance)
            {
                var cube = collectableCubePool.GetFreeElement(new Vector3(
                    Random.Range(-halfRoad, halfRoad),
                    0.5f,
                    spawn.position.z));

                cube.transform.SetParent(lastPlatform.collectableCubeZone);
                CollectingCubeCount++;
            }
            else
            {
                spawnChance++;
            }
        }
    }

    private void GenerateDeadlyCubes()
    {
        int tempCol = 0;
        int pattern = Random.Range(0, generatePatterns.Count - 1);

        for (int i = -1 * halfRoad; i <= halfRoad; i ++)
        {

            for (int j = 0; j < generatePatterns[pattern].sets[tempCol]; j++)
            {
                Vector3 position = new Vector3(i, j, lastPlatform.deadlyCubeZone.position.z);

                var cube = deadlyCubePool.GetFreeElement(position);
                cube.transform.SetParent(lastPlatform.deadlyCubeZone);
            }
            tempCol++;
        }
    }

    private void AnimatePlatform()
    {
        lastPlatform.transform.position = new Vector3(lastPlatform.transform.position.x, -100, lastPlatform.transform.position.z);
        lastPlatform.transform.DOMove(new Vector3(lastPlatform.transform.position.x, 0, lastPlatform.transform.position.z), platformAnimateTime);
    }

}
