using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private Transform dynamicObjects;

    public Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetObjectFromPool(GameObject gameObject)
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                return CreateNewGameObject(gameObject);
            }
            else
            {
                GameObject _object = objectList.Dequeue();
                _object.SetActive(true);
                _object.transform.SetParent(transform);
                return _object;
            }
        }
        else
        {
            return CreateNewGameObject(gameObject);
        }
    }

    private GameObject CreateNewGameObject(GameObject gameObject)
    {
        GameObject newGameObject = Instantiate(gameObject);
        newGameObject.name = gameObject.name;
        newGameObject.transform.SetParent(dynamicObjects);
        return newGameObject;
    }

    public void ReturnObjectBackToPool(GameObject gameObject)
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, newObjectQueue);
        }

        gameObject.transform.SetParent(transform);
        gameObject.SetActive(false);
    }
}
