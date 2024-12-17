
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private Animator animator; // Animatör bileþeni
    private bool isPlayerNear = false; // Oyuncunun kapýya yakýn olup olmadýðýný kontrol eder

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // Örneðin "E" tuþu ile kapýyý aç
        //{
        //    animator.SetBool("isopendoor", true); // isOpenDoor parametresini aktif et
        //}
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // Oyuncu yaklaþtýðýnda
        {
            isPlayerNear = true;
            Debug.Log("Player detected, switching scene!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Bir sonraki sahne
            animator.SetBool("opendoor", true);
        }
        if (col.gameObject.tag == "door") // Oyuncu yaklaþtýðýnda
        {
            Debug.Log("kapýdan gecti");
           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncu uzaklaþtýðýnda
        {
            isPlayerNear = false;
            animator.SetBool("opendoor", false); // Kapýyý kapat
        }
    }
}
