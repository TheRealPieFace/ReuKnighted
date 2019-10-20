using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> hazardsToActivate;
    public List<GameObject> objectsToActivate;
    public List<GameObject> hazardsToDeActivate;
    public List<GameObject> objectsToDeActivate;

    public bool needsSlab;
    public GameObject slab;
    private AudioManager audio;

    void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        audio.Play("Switch");
        //************OBJECTS************//

        //ACTIVATE
        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            objectsToActivate[i].SetActive(true);
        }
        //DE-ACTIVATE
        for (int i = 0; i < objectsToDeActivate.Count; i++)
        {
            objectsToDeActivate[i].SetActive(false);
        }

        //************HAZARDS************//

        //DE-ACTIVATE
        for (int i = 0; i < hazardsToDeActivate.Count; i++)
        {
            hazardsToDeActivate[i].GetComponentInChildren<HazardScript>().isActive = false;
        }

        //ACTIVATE
        for (int i = 0; i < hazardsToActivate.Count; i++)
        {
            hazardsToActivate[i].GetComponentInChildren<HazardScript>().isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        audio.Play("Switch");
        //************OBJECTS************//

        //ACTIVATE
        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            objectsToActivate[i].SetActive(false);
        }
        //DE-ACTIVATE
        for (int i = 0; i < objectsToDeActivate.Count; i++)
        {
            objectsToDeActivate[i].SetActive(true);
        }

        //************HAZARDS************//

        //DE-ACTIVATE
        for (int i = 0; i < hazardsToDeActivate.Count; i++)
        {
            hazardsToDeActivate[i].GetComponentInChildren<HazardScript>().isActive = true;
        }

        //ACTIVATE
        for (int i = 0; i < hazardsToActivate.Count; i++)
        {
            hazardsToActivate[i].GetComponentInChildren<HazardScript>().isActive = false;
        }
    }
    
}
