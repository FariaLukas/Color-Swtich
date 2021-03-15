using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal : MonoBehaviour
{

    public float speed;
    bool right;
    //movimentação do obj, faz ele ir de um lado para o outro;
    void Update()
    {
        if(transform.position.x <= -3.6f)
        {
            right = true;
        }
        if(transform.position.x >= 0)
        {
            right = false;
          
        }
        if(right)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        else transform.Translate(Vector2.right * -speed * Time.deltaTime);
    }
}
