using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    [Header("Fruit Pool variables")]
    public List<Fruit> listFruitPool;
    public Fruit fruitPrefab;
    public int initialAmountFruits;
    private GameObject _fruitsHolder;

    [Header("Bomb Pool variables")]
    public List<Bomb> listBombPool;
    public Bomb bombPrefab;
    public int initialAmountBombs;
    private GameObject _bombsHolder;

    [Header("Sliced Fruit variables")]
    public List<SlicedFruit> listSlicedFruitPool;
    public SlicedFruit slicedFruitPrefab;
    public int initialAmountSlicedFruit;
    private GameObject _slicedFruitsHolder;

    [Header("Trail variables")]
    public List<TrailRenderer> listTrailPool;
    public TrailRenderer trailPrefab;
    public int initialAmountTrail;
    private GameObject _trailFruitsHolder;

    [Header("Explosion variables")]
    public List<GameObject> listExplosionPool;
    public GameObject explosionPrefab;
    public int initialAmountExplosion;
    private GameObject _explosionHolder;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        _fruitsHolder = new GameObject("Fruits Pool");
        _fruitsHolder.transform.position = Vector2.zero;
        for (int index = 0; index <= initialAmountFruits; index++)
        {
            Fruit _fruit = Instantiate(fruitPrefab);
            _fruit.transform.SetParent(_fruitsHolder.transform);
            _fruit.gameObject.SetActive(false);
            listFruitPool.Add(_fruit);
        }

        _bombsHolder = new GameObject("Bombs Pool");
        _bombsHolder.transform.position = Vector2.zero;
        for (int index = 0; index <= initialAmountBombs; index++)
        {
            Bomb _bomb = Instantiate(bombPrefab);
            _bomb.transform.SetParent(_bombsHolder.transform);
            _bomb.gameObject.SetActive(false);
            listBombPool.Add(_bomb);
        }

        _slicedFruitsHolder = new GameObject("Sliced Fruit Pool");
        _slicedFruitsHolder.transform.position = Vector2.zero;
        for (int index = 0; index <= initialAmountSlicedFruit; index++)
        {
            SlicedFruit _slicedFruit = Instantiate(slicedFruitPrefab);
            _slicedFruit.transform.SetParent(_slicedFruitsHolder.transform);
            _slicedFruit.gameObject.SetActive(false);
            listSlicedFruitPool.Add(_slicedFruit);
        }
    
        _trailFruitsHolder = new GameObject("Trail Pool");
        _trailFruitsHolder.transform.position = Vector2.zero;
        for (int index = 0; index <= initialAmountTrail; index++)
        {
            TrailRenderer _slicedFruit = Instantiate(trailPrefab);
            _slicedFruit.transform.SetParent(_trailFruitsHolder.transform);
            _slicedFruit.gameObject.SetActive(false);
            listTrailPool.Add(_slicedFruit);
        }

        _explosionHolder = new GameObject("Explosion Pool");
        _explosionHolder.transform.position = Vector2.zero;
        for (int index = 0; index <= initialAmountExplosion; index++)
        {
            GameObject _explosion = Instantiate(explosionPrefab);
            _explosion.transform.SetParent(_explosionHolder.transform);
            _explosion.gameObject.SetActive(false);
            listExplosionPool.Add(_explosion);
        }
    }

    public Fruit TryToGetFruit()
    {
        Fruit _toReturn = null;

        for (int index = 0; index < listFruitPool.Count; index++)
        {
            Fruit _possibleBullet = listFruitPool[index];
            if (!_possibleBullet.gameObject.activeSelf)
            {
                _toReturn = _possibleBullet;
                break;
            }
        }

        if (_toReturn == null)
        {
            _toReturn = Instantiate(fruitPrefab);
            _toReturn.transform.SetParent(_fruitsHolder.transform);
            listFruitPool.Add(_toReturn);
        }

        _toReturn.gameObject.SetActive(true);

        return _toReturn;
    }

    public Bomb TryToGetBomb()
    {
        Bomb _toReturn = null;

        for (int index = 0; index < listBombPool.Count; index++)
        {
            Bomb _possibleBullet = listBombPool[index];
            if (!_possibleBullet.gameObject.activeSelf)
            {
                _toReturn = _possibleBullet;
                break;
            }
        }

        if (_toReturn == null)
        {
            _toReturn = Instantiate(bombPrefab);
            _toReturn.transform.SetParent(_bombsHolder.transform);
            listBombPool.Add(_toReturn);
        }

        _toReturn.gameObject.SetActive(true);

        return _toReturn;
    }

    public SlicedFruit TryToGetSlicedFruit()
    {
        SlicedFruit _toReturn = null;

        for (int index = 0; index < listSlicedFruitPool.Count; index++)
        {
            SlicedFruit _possibleBullet = listSlicedFruitPool[index];
            if (!_possibleBullet.gameObject.activeSelf)
            {
                _toReturn = _possibleBullet;
                break;
            }
        }

        if (_toReturn == null)
        {
            _toReturn = Instantiate(slicedFruitPrefab);
            _toReturn.transform.SetParent(_slicedFruitsHolder.transform);
            listSlicedFruitPool.Add(_toReturn);
        }

        _toReturn.gameObject.SetActive(true);

        return _toReturn;
    }

    public TrailRenderer TryToGetTrail()
    {
        TrailRenderer _toReturn = null;

        for (int index = 0; index < listTrailPool.Count; index++)
        {
            TrailRenderer _possibleBullet = listTrailPool[index];
            if (!_possibleBullet.gameObject.activeSelf)
            {
                _toReturn = _possibleBullet;
                break;
            }
        }

        if (_toReturn == null)
        {
            _toReturn = Instantiate(trailPrefab);
            _toReturn.transform.SetParent(_trailFruitsHolder.transform);
            listTrailPool.Add(_toReturn);
        }

        _toReturn.gameObject.SetActive(true);

        return _toReturn;
    }

    public GameObject TryToGetExplosion()
    {
        GameObject _toReturn = null;

        for (int index = 0; index < listExplosionPool.Count; index++)
        {
            GameObject _possibleBullet = listExplosionPool[index];
            if (!_possibleBullet.gameObject.activeSelf)
            {
                _toReturn = _possibleBullet;
                break;
            }
        }

        if (_toReturn == null)
        {
            _toReturn = Instantiate(explosionPrefab);
            _toReturn.transform.SetParent(_explosionHolder.transform);
            listExplosionPool.Add(_toReturn);
        }

        _toReturn.gameObject.SetActive(true);

        return _toReturn;
    }
}