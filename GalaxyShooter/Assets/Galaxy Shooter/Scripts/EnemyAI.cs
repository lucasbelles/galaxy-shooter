using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float _speed = 5.0f;


	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6)
        {
            float _RandomX = Random.Range(-8.0f, 8.0f);
            transform.position = new Vector3(_RandomX, 6.0f, 0);
        }
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.health = player.health - 1;

            if (player.health <= 0)
            {
                Destroy(player);
            }
        }
        else if (other.tag == "Laser")
        {
            Laser laser = other.GetComponent<Laser>();
            Destroy(laser);
        }

        Destroy(this.gameObject);
    }
}
