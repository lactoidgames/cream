using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerScript : MonoBehaviour {

	public static ObjectPoolerScript current;
	public GameObject[] objectPrefabs;
	public int[] amountToPool;
	public int defaultPooledAmount = 5;

	List<GameObject>[] pooledObjects;

	void Awake()
	{
		current = this;
	}

	void Start ()
	{
		pooledObjects = new List<GameObject>[objectPrefabs.Length];
		
		int i = 0;
		foreach (GameObject objectPrefab in objectPrefabs)
		{
			pooledObjects[i] = new List<GameObject>(); 
			
			int pooledAmount;
			
			if(i < amountToPool.Length) 
				pooledAmount = amountToPool[i];
			else
				pooledAmount = defaultPooledAmount;
			
			for (int n=0; n < pooledAmount; n++)
			{
				GameObject obj = (GameObject)Instantiate(objectPrefab);
				obj.name = objectPrefab.name;
				PoolObject(obj);
			}
			
			i++;
		}
	}
	
	public void PoolObject (GameObject obj)
	{
		for ( int i=0; i<objectPrefabs.Length; i++)
		{
			if(objectPrefabs[i].name == obj.name)
			{
				obj.SetActive(false);
				pooledObjects[i].Add(obj);
				return;
			}
		}
	}

	public GameObject GetPooledObject(string objectType)
	{
		for(int i=0; i < objectPrefabs.Length; i++)
		{
			GameObject prefab = objectPrefabs[i];
			if(prefab.name == objectType)
			{
				for (int j = 0; j < pooledObjects[i].Count; j++)
				{
					if(!pooledObjects[i][j].activeInHierarchy)
					{
						GameObject pooledObject = pooledObjects[i][j];
						return pooledObject;
					} 
				}
				break;
			}
		}
		return null;
	}
}
