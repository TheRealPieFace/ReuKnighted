using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPCEngine;

public class CharacterSwap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public TPCamera TPCam;
    public int objectiveComplete = 0;
    public GameObject winSplash;
    public GameObject audioManager;
    public int currentPlayer = 1;

    private bool p1enabled = true;
    private bool p2enabled = false;

    private bool reenable;
    public GameObject interactableInRange;
    public bool isByInteraction;

    void Start()
    {
        player2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && p1enabled){  
            enableP2();
        }
        else if(Input.GetKeyDown(KeyCode.Q) && p2enabled){
            enableP1();
        }
    }

    public void enableP2(){
        player1.GetComponent<TPCharacter>().enabled = false;
        player1.GetComponent<PlayerInteraction>().enabled = false;
        player1.GetComponent<StandaloneController>().enabled = false;
        //player1.GetComponent<PlayerInteraction>().enabled = false;
        player1.tag = "NotPlayer";
        player2.GetComponent<TPCharacter>().enabled = true;
        player2.GetComponent<PlayerInteraction>().enabled = true;
        //player2.GetComponent<StandaloneController>().enabled = true;
        //player2.GetComponent<PlayerInteraction>().enabled = true;
        player2.tag = "Player";
        TPCam.Target = player2.transform;
        TPCam.StartUp();
        p1enabled = false;
        p2enabled =true;
        CheckInteractions();
        currentPlayer = 2;
    }

    public void enableP1(){
        player2.GetComponent<TPCharacter>().enabled = false;
        player2.GetComponent<StandaloneController>().enabled = false;
        player2.GetComponent<PlayerInteraction>().enabled = false;
        //player2.GetComponent<PlayerInteraction>().enabled = false;
        player2.tag = "NotPlayer";
        player1.GetComponent<TPCharacter>().enabled = true;
        player1.GetComponent<PlayerInteraction>().enabled = true;
        //player1.GetComponent<StandaloneController>().enabled = true;
        //player1.GetComponent<PlayerInteraction>().enabled = true;
        player1.tag = "Player";
        TPCam.Target = player1.transform;
        TPCam.StartUp();
        p1enabled = true;
        p2enabled =false;
        CheckInteractions();
        currentPlayer = 1;
    }

    public void WinGameCheck()
    {
        if (objectiveComplete == 2)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("You Win!");
            winSplash.SetActive(true);
            Time.timeScale = 0f;
            
        } else
        {
            Debug.Log("1 to go.");
        }
    }


    void CheckInteractions()
    {
        if (reenable)
        {
            EnableInteraction(interactableInRange);
            reenable = false;
        }

        if (isByInteraction)
        {
            DisableInteraction(interactableInRange);
            reenable = true;
            isByInteraction = false;
        }
    }


    void DisableInteraction(GameObject interactable)
    {

        interactable.GetComponent<SwitchScript>().enabled = false;
            //disable switch script
    }

    void EnableInteraction(GameObject interactable)
    {
        //enable switch script
        interactable.GetComponent<SwitchScript>().enabled = true;
    }
}
