
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private Animator animator; // Animat�r bile�eni
    private bool isPlayerNear = false; // Oyuncunun kap�ya yak�n olup olmad���n� kontrol eder

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // �rne�in "E" tu�u ile kap�y� a�
        //{
        //    animator.SetBool("isopendoor", true); // isOpenDoor parametresini aktif et
        //}
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // Oyuncu yakla�t���nda
        {
            isPlayerNear = true;
            Debug.Log("Player detected, switching scene!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Bir sonraki sahne
            animator.SetBool("opendoor", true);
        }
        if (col.gameObject.tag == "door") // Oyuncu yakla�t���nda
        {
            Debug.Log("kap�dan gecti");
           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncu uzakla�t���nda
        {
            isPlayerNear = false;
            animator.SetBool("opendoor", false); // Kap�y� kapat
        }
    }
}
