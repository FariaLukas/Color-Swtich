using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionar : MonoBehaviour
{
    public float velocity;
    //faz o objeto ficar rotacionando;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocity));
    }
}
