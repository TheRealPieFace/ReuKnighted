using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScript : MonoBehaviour
{
    public GameObject hazard;
    public bool deactivate = true;
    private GameObject player;
    private bool inRange;
    private bool isOn = false;
    public List<GameObject> hazardsToActivate;
    public List<GameObject> hazardsToDeActivate;
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeActivate;
    public GameObject prompt;
    public Animator anim;
    private AudioManager audio;
    public CharacterSwap cs;


    

    void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.tag == "Player")
        {
            prompt.SetActive(true);
            inRange = true;
            cs.isByInteraction = true;
            cs.interactableInRange = this.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            prompt.SetActive(false);
            inRange = false;
            cs.isByInteraction = false;
        }
    }

    void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        cs = FindObjectOfType<CharacterSwap>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            anim.SetBool("isOn", isOn);
            audio.Play("Switch");
            for (int i = 0; i < hazardsToActivate.Count; i++)
            {
                hazardsToActivate[i].GetComponentInChildren<HazardScript>().isActive = isOn;

            }
            for (int i = 0; i < objectsToActivate.Count; i++)
            {
                objectsToActivate[i].SetActive(true);
            }
            for (int i = 0; i < hazardsToDeActivate.Count; i++)
            {
                hazardsToDeActivate[i].GetComponentInChildren<HazardScript>().isActive = !isOn;
            }
            for (int i = 0; i < objectsToDeActivate.Count; i++)
            {
                objectsToDeActivate[i].SetActive(false);
            }
        }
        if(inRange == true && Input.GetKeyDown(KeyCode.Q)){
            prompt.SetActive(false);
        }
    }

    
}
