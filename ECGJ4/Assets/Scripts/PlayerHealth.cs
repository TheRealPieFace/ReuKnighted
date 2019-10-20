using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TPCEngine;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public GameObject characterSwap;
    public GameObject dedSplash;
    private AudioManager audioManager;
    private CharacterSwap cs;

    CapsuleCollider playerCollider;
    TPCharacter characterController;
    Rigidbody characterRigidbody;
    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    public Image[] hearts;
    public Sprite heart;


    void Awake()
    {
        cs = FindObjectOfType<CharacterSwap>();
        audioManager = FindObjectOfType<AudioManager>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        characterController = GetComponent<TPCharacter>();
        playerCollider = GetComponent<CapsuleCollider>();
        characterRigidbody = GetComponent<Rigidbody>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
        if (damaged)
        {
            anim.SetTrigger("Damage");
        }
        else
        {
            anim.ResetTrigger("Damage");
        }

        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;
        
        currentHealth -= amount;

        // TODO Play the hurt sound effect.
        if(cs.currentPlayer == 1)
        {
            audioManager.Play("Bors_Attack3");
        } else if (cs.currentPlayer == 2)
        {
            audioManager.Play("Mousealot_Attack3");
        }
        


        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        characterRigidbody.isKinematic = true;
        characterController.enabled = false;
        playerCollider.enabled = false;
        characterSwap.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        dedSplash.SetActive(true);

        if (cs.currentPlayer == 1)
        {
            audioManager.Play("Bors_Death");
        }
        else if (cs.currentPlayer == 2)
        {
            audioManager.Play("Mousealot_Death");
        }
    }
}