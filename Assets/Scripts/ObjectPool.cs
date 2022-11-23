using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ObjectPoolItem{
    // public string key;
    [Range(0,100)]
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
    
}
[System.Serializable]
public struct customDiksi{
    public string key;
    public ObjectPoolItem value;
}


public class ObjectPool : MonoBehaviour{

// } ,ISerializationCallbackReceiver{
    public static ObjectPool ins;
    public List<GameObject> pooledObjects;
    public List<customDiksi> diksiObjectPool;
    // public GameObject objectToPool;
    // public int amountToPool;
    // public bool shouldExpand;

    void Awake(){
        ins = this;
    }
    
    // Start is called before the first frame update
    void Start(){
        pooledObjects = new List<GameObject>();
        // foreach(ObjectPoolItem item in objToPool.Values ){
        foreach(customDiksi item in diksiObjectPool){
            Debug.Log("Start Pooling " + item.key);
            for(int i = 0; i < item.value.amountToPool; i++){
                GameObject obj = (GameObject)Instantiate(item.value.objectToPool);
                obj.name = item.key;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public GameObject GetPooledObject(string name){
        for (int i = 0; i < pooledObjects.Count; i++){
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].name == name){
                Debug.Log("Use pooled " + pooledObjects[i].name);
                return pooledObjects[i];
            }
        }
         foreach (customDiksi diksi in diksiObjectPool){
            if (diksi.key == name) {
                if (diksi.value.shouldExpand) {
                    GameObject obj = (GameObject)Instantiate(diksi.value.objectToPool);
                    obj.name = name;
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
    public void CleanObjectPool(){
        for (int i = 0; i < pooledObjects.Count; i++){
            Destroy(pooledObjects[i]);
        }
        pooledObjects = new List<GameObject>();
    }
}
