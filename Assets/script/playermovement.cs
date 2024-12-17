using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    float speedAmount = 5f;
    float jumpamount = 3f;
    float goldcount = 0f;
    public Animator animator;
    // Alt�n toplama sesi
    public AudioClip goldPickupSound;
    private AudioSource audioSource; // Ses kayna��n� kontrol edecek

    void Start()
    {
        rgb=GetComponent<Rigidbody2D>();
        // E�er bir AudioSource yoksa yeni bir tane ekle
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Yeni bir AudioSource ekle
        }

        // Sesin oyun ba��nda �almamas�n� sa�la
        audioSource.playOnAwake = false;
        audioSource.clip = goldPickupSound; // Alt�n toplama sesini ayarla

        // Ses bile�eninin olup olmad���n� kontrol et
        if (audioSource == null)
        {
            Debug.LogError("AudioSource bile�eni bulunamad�! Ses �al�namaz.");
        }
        else
        {
            Debug.Log("AudioSource bile�eni ba�ar�yla ayarland�.");
        }
    }

    
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity*speedAmount*Time.deltaTime;
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetButtonDown("Jump"))
        {
            rgb.AddForce(Vector3.up * jumpamount, ForceMode2D.Impulse);
            animator.SetBool("isJumping",true);
        }
        if (animator.GetBool("isJumping")&& Mathf.Approximately(rgb.velocity.y,0))
        {
            animator.SetBool("isJumping",false);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gold")) // Alt�na dokunduysa
        {
            goldcount++;
            Destroy(collision.gameObject, 0.1f); // Alt�n� yok et

            // Ses �almay� dene ve hata ay�klama log'u ekle
            if (audioSource != null && goldPickupSound != null)
            {
                Debug.Log("Alt�n topland�! Ses �alacak...");
                audioSource.Play(); // Alt�n toplama sesini �al
            }
            else
            {
                Debug.LogError("AudioSource veya ses dosyas� eksik.");
            }

            Debug.Log("Gold Count: " + goldcount);
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetBool("isstop", false);
        }
        else
        {
            animator.SetBool("isstop", true);
        }
       
    }
 



}
