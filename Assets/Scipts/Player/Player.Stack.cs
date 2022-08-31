using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class Player 
{
    [SerializeField] private CollactableCube startCube;
    [SerializeField] private Transform stickman;

    private Vector3 playerPostion = new Vector3(0, 1.05f, 0);
    private Vector3 startCubePosition = Vector3.zero;
    private float jumpTime = 0.2f;

    private List<CollactableCube> collactableCubes;

    private void StackAwake()
    {
        collactableCubes = new List<CollactableCube>(10);
    }

    private void StackStart()
    {
        SetDefaultStack();
    }

    private void ClearStack()
    {
        collactableCubes.Clear();

        startCube.transform.SetParent(cubeHolder);
        startCube.EnableCollider();
        collactableCubes.Add(startCube);
    }

    private void SetDefaultStack()
    {
        ClearStack();

        stickman.localPosition = playerPostion;
        startCube.transform.localPosition = startCubePosition;
    }

    private void AddColactableCubeToStack(CollactableCube collectedCube)
    {
        collectedCube.transform.SetParent(cubeHolder);

        collactableCubes.Add(collectedCube);

        ReAnimateStack();
    }

    private void AnimateStack(Transform cubeTransform, Vector3 newPos)
    {
        cubeTransform.DOLocalMove(newPos, jumpTime);
    }

    public Vector1 GetCubeCount()
    {
        return new Vector1(collactableCubes.Count);
    }

    public float GetHight()
    {
        return collactableCubes.Count;
    }

    private void ReAnimateStack()
    {
        int highCounter = collactableCubes.Count - 1;
        foreach (var cube in collactableCubes)
        {
            AnimateStack(cube.transform,
                new Vector3(
                    0,
                    highCounter,
                    0)
                );

            highCounter--;
        }
        AnimateStack(stickman, new Vector3(0, collactableCubes.Count, 0));
    }
}
