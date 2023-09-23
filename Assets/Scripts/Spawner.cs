using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Enemy _enemyPrefab;

    private Transform[] _spawners;
    private Transform _activeSpawner;
    private int _delay = 2;

    private void Start()
    {
        _spawners = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _spawners[i] = _path.GetChild(i).transform;
        }

        StartCoroutine(Generate());
    }

    private Transform GetSpawner()
    {
        int randomNumber = Random.Range(0, _spawners.Length);
        return _spawners[randomNumber];
    }

    private IEnumerator Generate()
    {
        while (true)
        {
            _activeSpawner = GetSpawner();
            Instantiate(_enemyPrefab, _activeSpawner);
            yield return new WaitForSeconds(_delay);
        }
    }
}
