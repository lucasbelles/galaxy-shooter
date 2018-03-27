using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    //Instances of the gameObject
    [SerializeField]
    private GameObject _prefabLaser;

    [SerializeField]
    private GameObject _tripleShoot;

    [SerializeField]
    private float _speed = 5.0f;

    public bool canTripleShoot = false;
    public bool canFasterPlayer = false;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {

        Movement();

        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        //Este métedo serve para instanciar um objeto 'laser' quando for pressionado a telca espaço.
        if (Time.time > _canFire)
        {
            if (canTripleShoot)
            {
                Instantiate(_tripleShoot, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_prefabLaser, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        // Returns the value of the virtual axis identified by axisName.
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        if (canFasterPlayer)
        {
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * 1.5f * verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }
        


        //Restricting the y axis
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //Restricting the x axis
        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        else if (transform.position.x <= -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
    }

    //methods for to call the method couratine

    public void FasterPlayerOn()
    {
        canFasterPlayer = true;
        Debug.Log("Here!");
        StartCoroutine(FasterPlayerPowerDownRoutine());
    }

    public void TripleShotPowerUpOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }


    //methods couratine
    public IEnumerator FasterPlayerPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canFasterPlayer = false;
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return  new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
}
