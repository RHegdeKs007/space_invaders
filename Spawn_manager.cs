using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopspawning = false;
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
        while(_stopspawning == false)
        {
            Vector3 postospawn = new Vector3(Random.Range(-8f,8f),7,0);
            GameObject newEnemy =  Instantiate(_enemyPrefab,postospawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
        //wait one frame and then this is called
        //we wont get here
        
        //while loop
        //Instantiate enemy prefab
        //yield wait for 5 secs
    }
    public void onplayerDeath() 
    {
        _stopspawning = true;
    }
}
