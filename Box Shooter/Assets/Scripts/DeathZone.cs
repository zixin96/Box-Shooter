using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Respawn")
        {
            GameManager.gm.RestartGame();
        }
    }
    
    
}
