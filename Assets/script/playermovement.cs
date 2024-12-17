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
    // Altýn toplama sesi
    public AudioClip goldPickupSound;
    private AudioSource audioSource; // Ses kaynaðýný kontrol edecek

    void Start()
    {
        rgb=GetComponent<Rigidbody2D>();
        // Eðer bir AudioSource yoksa yeni bir tane ekle
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Yeni bir AudioSource ekle
        }

        // Sesin oyun baþýnda çalmamasýný saðla
        audioSource.playOnAwake = false;
        audioSource.clip = goldPickupSound; // Altýn toplama sesini ayarla

        // Ses bileþeninin olup olmadýðýný kontrol et
        if (audioSource == null)
        {
            Debug.LogError("AudioSource bileþeni bulunamadý! Ses çalýnamaz.");
        }
        else
        {
            Debug.Log("AudioSource bileþeni baþarýyla ayarlandý.");
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
        if (collision.gameObject.CompareTag("gold")) // Altýna dokunduysa
        {
            goldcount++;
            Destroy(collision.gameObject, 0.1f); // Altýný yok et

            // Ses çalmayý dene ve hata ayýklama log'u ekle
            if (audioSource != null && goldPickupSound != null)
            {
                Debug.Log("Altýn toplandý! Ses çalacak...");
                audioSource.Play(); // Altýn toplama sesini çal
            }
            else
            {
                Debug.LogError("AudioSource veya ses dosyasý eksik.");
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
