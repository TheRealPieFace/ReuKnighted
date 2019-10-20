using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public Transform carryPoint;
    [SerializeField]
    private bool canCarry = false;
    [SerializeField]
    private bool canDrop = false;
    private GameObject interactableObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canCarry && Input.GetKeyDown(KeyCode.E)){
            interactableObj.transform.position = carryPoint.transform.position;
            interactableObj.transform.parent = carryPoint;
            interactableObj.GetComponent<Rigidbody>().isKinematic = true;
            interactableObj.GetComponent<BoxCollider>().enabled = false;
            canCarry = false;
            canDrop = true;
        }else if (canDrop && Input.GetKeyDown(KeyCode.E)){
            interactableObj.transform.parent = null;
            interactableObj.GetComponent<Rigidbody>().isKinematic = false;
            interactableObj.GetComponent<BoxCollider>().enabled = true;
            interactableObj = null;
            canDrop = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Box"){
            canCarry = true;
            interactableObj = other.gameObject;
            Debug.Log("Can carry: " + canCarry + " Can Drop " + canDrop);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Box")
        {
            if (canCarry)
            {
                canCarry = false;
                interactableObj.transform.parent = null;
            }
            if (canDrop)
            {
                interactableObj.transform.parent = null;
                interactableObj.GetComponent<Rigidbody>().isKinematic = false;
                interactableObj.GetComponent<BoxCollider>().enabled = true;
                interactableObj = null;
                canDrop = false;
            }
        }
    }
}
