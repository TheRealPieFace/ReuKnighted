using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    Rigidbody playerRigidbody;                  // Reference to the player's rigidbody.
    public Animator anim;                      // Reference to this animation

    private Vector3 moveDirection;
    public float knockBackForce = -500f;
    public bool isActive = false;
    

    void OnTriggerEnter (Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerRigidbody = player.GetComponent<Rigidbody>();

        if (other.gameObject == player && isActive)
        {
            Debug.Log("hit the player");
            playerHealth.TakeDamage(1);
            moveDirection = playerRigidbody.transform.position - this.gameObject.transform.position;
            //playerRigidbody.AddForce(moveDirection.normalized * knockBackForce);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            Activate();
        } else
        {
            Deactivate();
        }
    }

    void Activate()
    {
        anim.SetBool("isActive", true);
    }

    void Deactivate()
    {
        anim.SetBool("isActive", false);
    }
}
