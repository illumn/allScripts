using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float Speed;
   
   

    private void Start()
    {
        Speed = Random.Range(0.5f, 1.5f);
    }

    private void FixedUpdate()
    {
      
        transform.Translate(Vector3.right* Speed * Time.deltaTime);
        
    }
}
