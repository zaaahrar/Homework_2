using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _enemyPrefab;

    private Transform[] _spawners;
    private Transform _activeSpawner;
    private float _gameTime;
    private int _delay = 2;

    private void Start()
    {
        _spawners = new Transform[_path.childCount];

        for(int i = 0; i < _path.childCount; i++)
        {
            _spawners[i] = _path.GetChild(i).transform;
        }
    }

    private void Update()
    {
        Generate();
    }

    private Transform GetSpawner()
    {
        int randomNumber = Random.Range(0, _spawners.Length);

        return _spawners[randomNumber];
    }

    private void Generate()
    {
        _gameTime += Time.deltaTime;

        if (_gameTime >= _delay)
        {
            _gameTime = 0;
            _activeSpawner = GetSpawner();
            Instantiate(_enemyPrefab, _activeSpawner);
        }
    }
}
