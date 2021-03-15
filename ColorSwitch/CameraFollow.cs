using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public float speed;

    public void Update()
    {
        //caso a altura da camera + offset for menor q o player, movimenta a camera pra altura do player;
        if ( transform.position.y +0.5f < player.transform.position.y)
        {
            Vector3 newYposition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newYposition, speed * Time.deltaTime);
        }
    }
}
