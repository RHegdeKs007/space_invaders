using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
        

        
    }

    //spawn game object every 5sec
    //create a coroutine of type IENUMERATOR -- yeild events
    //while
    IEnumerator SpawnRoutine()
    {   
        while(true)
        {
            Vector3 postospawn = new Vector3(Random.Range(-8f,8f),7,0);
            Instantiate(_enemyPrefab,postospawn,Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
        //wait one frame and then this is called
        //we wont get here
        
        //while loop
        //Instantiate enemy prefab
        //yield wait for 5 secs
    }
}
