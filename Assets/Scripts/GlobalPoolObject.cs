using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalPoolObject : MonoBehaviour
{
    public static GlobalPoolObject Instance;

    private List<GameObject> _gameobject;

    //public Dictionary<GameObject, List<GameObject>> _pooledObjects = new Dictionary<GameObject, List<GameObject>>();

    public int PoolSize = 15;

    public GameObject EmptyPrefab;
    public GameObject MissilePrefab;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _gameobject = new List<GameObject>();

        for (int i = 0; i < PoolSize; i++)
        {
            GameObject empty = Instantiate(EmptyPrefab, transform);
            empty.SetActive(false);
            _gameobject.Add(empty);

            if (i == 0)
            {
                FuseComponents(MissilePrefab, empty);
                empty.SetActive(true);
            }
        }  

    }

    public GameObject GetEmpty()
    {
        for (int i = 0 ; i < _gameobject.Count; i++)
        {
            if (!_gameobject[i].activeInHierarchy)
            {
                _gameobject[i].SetActive(true);
                return _gameobject[i];
            }
        }

        GameObject newEmpty = Instantiate(EmptyPrefab, transform);
        _gameobject.Add(newEmpty);
        newEmpty.SetActive(true);
        return newEmpty;
    }

    public void FuseComponents(GameObject Prefab,GameObject emptyGameObject)
    {
        Component[] components = Prefab.GetComponents<Component>();
        foreach (Component component in components)
        {
            Debug.Log(component);
        }
        addComponent(emptyGameObject, components);
        emptyGameObject.GetComponents<SpriteRenderer>()[0].sprite = Prefab.GetComponents<SpriteRenderer>()[0].sprite;
        emptyGameObject.GetComponents<Missile>()[0].speed = Prefab.GetComponents<Missile>()[0].speed;
    }

    public void ClearOneEmpty(GameObject empty)
    {
        empty.SetActive(false);
        //remove all components from the empty gameobject
        Component[] components = empty.GetComponents<Component>();
        foreach (Component component in components)
        {
            if (component.GetType() == typeof(Transform))
            {
                continue;
            }
            Destroy(component);
        }
    }

    public void addComponent(GameObject emptyGameObject, Component[] componentsToAdd)
    {
        foreach (Component component in componentsToAdd)
        {
            //exept the transform component
            if (component.GetType() == typeof(Transform))
            {
                continue;
            }
            Component newComponent = emptyGameObject.AddComponent(component.GetType());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
