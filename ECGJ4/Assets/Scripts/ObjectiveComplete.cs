using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour
{
    public CharacterSwap characterSwap;
    private AudioManager audio;

    void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (characterSwap.currentPlayer == 1)
        {
            audio.Play("Bors_Celebration");
        }
        else if (characterSwap.currentPlayer == 2)
        {
            audio.Play("Mousealot_Celebration");
        }
    
        characterSwap.objectiveComplete += 1;
        characterSwap.WinGameCheck();
}
        

    void OnTriggerExit (Collider other)
    {
        characterSwap.objectiveComplete -= 1;
    }
}
