using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
         while (true)
         {
             yield return  new WaitForSeconds(Random.Range(3,10));
             Instantiate(EnemyPrefab,transform.position,Quaternion.identity);
         }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawIcon(transform.position,"item.png",true);
    }
}
