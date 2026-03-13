using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget; //Nästa teleport
    public GameObject Player; //player
    private void OnTriggerEnter2D(Collider2D collision) //Om vi triggar en kollision, byt position till nästa telepor5t
     {  Player.transform.position = teleportTarget.transform.position; }
}
