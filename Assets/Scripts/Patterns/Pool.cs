using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public Transform parent;
    public GameObject[] prefabs;
    private List<GameObject> items = new List<GameObject>();

    public GameObject GetItem
    {
        get
        {
            if (items.Count == 0) AddVarietyOfPrefabs();

            for (int i = 0; i < items.Count; i++)
                if (!items[i].activeSelf)
                    return items[i];

            return NewItem();
        }
    }
    public GameObject GetRandomItem
    {
        get
        {
            if (items.Count == 0) AddVarietyOfPrefabs();

            List<GameObject> allItems = new List<GameObject>(0);
            for (int i = 0; i < items.Count; i++)
                if (!items[i].activeSelf)
                    allItems.Add(items[i]);

            return allItems.Count > 0 ? allItems[Random.Range(0, allItems.Count)] : NewItem();
        }
    }
    public GameObject[] GetActiveItems
    {
        get
        {
            List<GameObject> activeItems = new List<GameObject>(0);

            for (int i = 0; i < items.Count; i++)
                if (items[i].activeSelf)
                    activeItems.Add(items[i]);

            return activeItems.ToArray();
        }
    }

    private GameObject NewItem()
    {
        GameObject gameObject = GameObject.Instantiate(GetRandomPrefab(), parent);
        gameObject.SetActive(false);
        items.Add(gameObject);
        return gameObject;
    }
    private GameObject GetRandomPrefab()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
    private void AddVarietyOfPrefabs()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject gameObject = GameObject.Instantiate(prefabs[i], parent);
            gameObject.SetActive(false);
            items.Add(gameObject);
        }
    }
}
