using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // allows us to make instances of this class editable from within the Inspector. NOTE: THIS WON'T APPEAR IN THE INSPECTOR UNTIL WE HAVE A FIELD OF THE TYPE OBJECTPOOLITEM EXPOSED TO THE INSPECTOR VIA SCRIPTS SUCH AS PLAYER, WHICH REFERENCES THE TAG "LASER"
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}
public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    [SerializeField] List<ObjectPoolItem> itemsToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>(); //creating an empty list
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++) // iterating based on amountToPool which we set in the Inspector
            {
                GameObject obj = Instantiate(item.objectToPool);  //Instantiate based on amountToPool
                obj.SetActive(false);  //initially set each object to inactive within hierarchy
                pooledObjects.Add(obj);  //add inactive instantiated objects to list
            }
        }

    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)    //iterate through the list of gameObjects we filled in Start()
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) // checking to see if the item in our list is not currently active. If it is, the loop moves to the next object in the list. 
            {
                return pooledObjects[i]; // If not, we exit the method and hand the inactive object to the method that called GetPooledObject
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }

        return null; // if no objects are currently inactive, we exit the method and return nothing. 


    }

    // Update is called once per frame
    void Update()
    {

    }
}