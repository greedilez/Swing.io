using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingStackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject swingStackPrefab;

    [SerializeField] private Vector3 spawnPosition;

    private void Awake() => SpawnFirstSwingStack();

    private protected void SpawnFirstSwingStack() => Instantiate(swingStackPrefab, spawnPosition, Quaternion.identity);
}
