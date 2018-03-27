using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerUpID;
	
	void Update () {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

    // The OnTriggerEnter2D method allows you to receive a GameObject that has a colliding component on it.
    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Player")
        {

            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if(_powerUpID == 0){

                    player.TripleShotPowerUpOn();
                }
                else if (_powerUpID == 1)
                {
                    player.FasterPlayerOn(); 
                }
                else if (_powerUpID == 2)
                {
                    // to enable shields power up
                }
                
            }

            Destroy(this.gameObject);
        }
    }
}
