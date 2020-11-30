using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    #region Variables
    public static GroundSpawn instance;
    [SerializeField] private GameObject[] _groundPrefab;
    [SerializeField] private List<GameObject> _activeGrounds;
    [SerializeField] private float _spawnZ = 0.0f;
    [SerializeField] private int _amountsOfGrounds = 2;
    [SerializeField] private int _lastGroundIndex = 0;
    private GameObject go;
    #endregion

    #region Main Methods
    private void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        _activeGrounds = new List<GameObject>();
        for (int i = 0; i < _amountsOfGrounds; i++)
        {
            if (i < 2)
                Spawn(0);
            else
                Spawn();
        }
    }
    #endregion

    #region Helper Methods
    public void Spawn(int prefabIndex = -1)
    {
        if (prefabIndex == -1)
            go = Instantiate(_groundPrefab[RandomGroundIndex()]) as GameObject;
        else
            go = Instantiate(_groundPrefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * _spawnZ;
        _spawnZ = 80;
        _activeGrounds.Add(go);
    }

    public void DeSpawn()
    {
        Destroy(_activeGrounds[0]);
        _activeGrounds.RemoveAt(0);
    }

    private int RandomGroundIndex()
    {
        if (_groundPrefab.Length <= 1)
            return 0;
        int randomIndex = _lastGroundIndex;
        while (randomIndex == _lastGroundIndex)
        {
            randomIndex = Random.Range(0, _groundPrefab.Length);
        }
        _lastGroundIndex = randomIndex;
        return randomIndex;
    }

    #endregion
}


