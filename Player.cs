using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{   
    //PUBLIC OR PRIVATE REFERENCE
    //DATA TYPE (INT,FLOAT,BOOL,STRING)
    //every variable has a name
    //optional value assigned
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _firerate = 0.5f;
    [SerializeField]
    private float _canfire = -1f;
    [SerializeField]
    private int _lives = 3;

    private Spawn_manager _spawnmanager;

   

    // Start is called before the first frame update
    void Start()
    {
        //Take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        _spawnmanager = GameObject.Find("Spawn_manager").GetComponent<Spawn_manager>();
        
        if(_spawnmanager == null)
        {
            Debug.LogError("The spawn is null");
        }
    }

    // Update is called once per frame
    void Update()
    {   CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            FireLaser();
        }

       

        
    }
    void CalculateMovement()
    {
           float horizontalInput = Input.GetAxis("Horizontal");   
        float verticalInput = Input.GetAxis("Vertical");      
                       //New Vector3(1,0,0)
        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        
        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        transform.Translate( direction * _speed * Time.deltaTime);

        

        if (transform.position.y >=0)
        {
            transform.position = new Vector3(transform.position.x ,0 ,0);
        } 
        else if(transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x,-3.8f,0);
        }
        //transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-3.8f,0),0);
       
        if(transform.position.x > 11)
        {
            transform.position = new Vector3(-11,transform.position.y,0);
        }
        else if(transform.position.x < -11)
        {
            transform.position = new Vector3(11,transform.position.y,0);
        }

    }
    void FireLaser()
    {
         //if space key is pressed
        //spawn object           
           _canfire = Time.time + _firerate;
           Instantiate(_laserPrefab, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);

   
    }
    public void Damage()
    {
        _lives -= 1;
        //_lives = _lives - 1;
        //_lives--;
        if(_lives < 1)
        {   //communicate spawn manager to stop spawning
            _spawnmanager.onplayerDeath();
            Destroy(this.gameObject);
        }
    }
}
