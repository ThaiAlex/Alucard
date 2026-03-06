using UnityEngine;

public class Trap_HurtPlayer : MonoBehaviour
{

    private float waitToHurt = 1f; //vänta "x"f innan enemy ger skada till player
    private bool isTouching; //definerar om den rör vid player eller inte
    private HealthManager healthManager; //refererar till healthmanager scriptet
    public int damageToGive = 10; //hur mycker skada enemy får göra på player varje gånge den rör
    void Start()
    {
        healthManager = FindFirstObjectByType<HealthManager>(); //hitta healthmanager scriptet
    }
    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManager.HurtPlayer(damageToGive, transform);
                waitToHurt = 1f; //om enemy är nära nog att röra vid player, vänta "x"f, ge "x" damage
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive, transform);
            //om enemy colliderar med tag player, ge damage
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
            //om enemy colliderar med tag player, så är isTouching sant och enemy stannar för att attackera
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouching = false;
    }

}
