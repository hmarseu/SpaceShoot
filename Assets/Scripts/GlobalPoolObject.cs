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

            //if (i == 0)
            //{
            //    FuseComponents(MissilePrefab, empty);
            //    empty.SetActive(true);
            //}
        }  

    }

    public GameObject GetEmpty()
    {
        for (int i = 0 ; i < _gameobject.Count; i++)
        {
            if (!_gameobject[i].activeInHierarchy && _gameobject[i] != null)
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

    public void MakeCopyFromPrefab(GameObject emptyObject, GameObject SpawnPrefab)
    {
        emptyObject.tag = SpawnPrefab.tag;
        emptyObject.layer = SpawnPrefab.layer;
      
        Component[] components = emptyObject.GetComponents<Component>();
        foreach (var component in components)
        {
            if (!(component is Transform))
            {
                Destroy(component);
            }
        }

        Component[] prefabComponents = SpawnPrefab.GetComponents<Component>();
        foreach (var prefabComponent in prefabComponents)
        {
        
            if (prefabComponent is Transform)
                continue;

            System.Type type = prefabComponent.GetType();
            Component copy = emptyObject.AddComponent(type);

            if (prefabComponent is BoxCollider)
            {
                BoxCollider originalBoxCollider = (BoxCollider)prefabComponent;
                BoxCollider copyCollider = (BoxCollider)copy;
                copyCollider.isTrigger = originalBoxCollider.isTrigger;
            }
            if (prefabComponent is Rigidbody)
            {
                Rigidbody original = (Rigidbody)prefabComponent;
                Rigidbody copyy = (Rigidbody)copy;
                copyy.useGravity = original.useGravity;
                copyy.excludeLayers = original.excludeLayers;
                copyy.isKinematic = original.isKinematic;
            }
            if (prefabComponent is Hitable)
            {
                Hitable originalHitable = (Hitable)prefabComponent;
                Hitable copyHitable = (Hitable)copy;
                copyHitable.LifePoint = originalHitable.LifePoint;
            }
            if (prefabComponent is HitableBoss)
            {
                HitableBoss originalHitable = (HitableBoss)prefabComponent;
                HitableBoss copyHitable = (HitableBoss)copy;
                copyHitable.LifePoint = originalHitable.LifePoint;
                copyHitable.totalLP = originalHitable.totalLP;
            }
            if (prefabComponent is SpriteRenderer)
            {
                SpriteRenderer originalRenderer = (SpriteRenderer)prefabComponent;
                SpriteRenderer copyRenderer = (SpriteRenderer)copy;
                copyRenderer.sprite = originalRenderer.sprite;
            }
            if (prefabComponent is EnemyAI)
            {
                EnemyAI original = (EnemyAI)prefabComponent;
                EnemyAI copyA = (EnemyAI)copy;
                copyA.speed = original.speed;
                copyA.rotationSpeed = original.rotationSpeed;
                copyA.timeBetweenShots = original.timeBetweenShots;
                copyA.canShoot = original.canShoot;
                copyA.missilePrefab = original.missilePrefab;

            }
            else
            {
                
                System.Reflection.FieldInfo[] fields = type.GetFields();
                foreach (System.Reflection.FieldInfo field in fields)
                {
                    field.SetValue(copy, field.GetValue(prefabComponent));
                }
            }
        }
    }


  

    public void FuseComponents(GameObject Prefab,GameObject emptyGameObject)
    {
        emptyGameObject.tag = Prefab.tag;
        Component[] components = Prefab.GetComponents<Component>();
        foreach (Component component in components)
        {
            //Debug.Log(component);
        }
        addComponent(emptyGameObject, components);
        emptyGameObject.GetComponent<SpriteRenderer>().sprite = Prefab.GetComponent<SpriteRenderer>().sprite;
        emptyGameObject.GetComponent<Missile>().speed = Prefab.GetComponent<Missile>().speed;
        emptyGameObject.GetComponent<Rigidbody>().useGravity = false;
        emptyGameObject.GetComponent<Rigidbody>().isKinematic = true;
       
    }

    public void ClearOneEmpty(GameObject empty)
    {
        empty.SetActive(false);
        empty.transform.position = Vector3.zero;
        empty.transform.rotation = Quaternion.identity;
        //remove all components from the empty gameobject
        Component[] components = empty.GetComponents<Component>();
        Destroy(empty.GetComponent<ResolutionAdapter>());
        foreach (Component component in components)
        {
            if (component.GetType() == typeof(Transform))
            {
                continue;
            }
            if (component.GetType() == typeof(RectTransform))
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
