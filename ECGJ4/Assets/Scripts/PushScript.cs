using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour
{
    private GameObject player;

    void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(other.gameObject == player)
        {
            Debug.Log("enter");
            player.GetComponent<Animator>().SetBool("isPushing", true);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject == player)
        {
            player.GetComponent<Animator>().SetBool("isPushing", false);
        }

    }

}
