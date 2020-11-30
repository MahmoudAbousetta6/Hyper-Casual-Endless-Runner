using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstecalesManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstecalePrefab;
    [SerializeField] private Transform _ground;

    [SerializeField] private GameObject[] _spawnPoints;
    private int _index;
    private GameObject _currentPoint;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstecale), 0, 2f);

    }

    private void SpawnObstecale()
    {
        _index = Random.Range(0, _spawnPoints.Length);
        _currentPoint = _spawnPoints[_index];
        GameObject obj = Instantiate(_obstecalePrefab, _currentPoint.transform.position, Quaternion.identity);
        obj.transform.parent = _ground;
    }

}
