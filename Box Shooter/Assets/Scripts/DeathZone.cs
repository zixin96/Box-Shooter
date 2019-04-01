using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // DeathZone will restart the game upon collision
    void OnCollisionEnter(Collision newCollision)
    {
        
        if (newCollision.gameObject.tag == "Player")
        {
            // call the RestartGame function in the game manager
            GameManager.gm.RestartGame();
        }
    }
}
