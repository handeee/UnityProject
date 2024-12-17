using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    bool dead=false;

    public Transform floatingText;
    public Slider slider;
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
        if ((health-damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIdead();
    }
    void AmIdead()
    {
        if (health<=0) {
            dead = true;
        }
    }
}
