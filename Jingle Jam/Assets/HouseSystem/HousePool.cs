using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class HousePool : MonoBehaviour
{
    public GameObject prefab; 
    public int poolSize;
    private List<GameObject> pool;
    private bool poolWorking = false;

    [SerializeField] House firstHouse;

    void Start()
    {
        pool = new List<GameObject>();

        // Initialize the pool with the specified number of objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(true);
            if(i != 0)
            {
                int randomDist = Random.Range(2, 6);
                obj.transform.position = pool.Last().transform.position + new Vector3(randomDist, 0f, 0f);

            }
            else
                obj.transform.position = firstHouse.transform.position + new Vector3(5f, 0f, 0f);

            pool.Add(obj);
        }
    }

    private void FixedUpdate()
    {
        if(!poolWorking) 
            StartCoroutine(Wait(0.8f));
    }
 

    IEnumerator Wait(float delay)
    {
        poolWorking = true;

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // This code will be executed after the delay
        GameObject dummy = pool[0];
        int randomDist = Random.Range(2, 6);
        pool[0].transform.position = pool.Last().transform.position + new Vector3(randomDist, 0f, 0f);
        pool.RemoveAt(0);
        pool.Add(dummy);

        poolWorking = false;
    }


}
