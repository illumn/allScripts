using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody componentRigidbody;
    [SerializeField] private GameObject LosePanel;
    public int Velocity = 4;
    public int TurnSpeed = 2;
    private int maxSpeed = 15;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(SpeedIncrease());
    }
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(1);
        if (Velocity < maxSpeed)
        {
            Velocity += 1;
            StartCoroutine(SpeedIncrease());
        }
    }

    private void FixedUpdate()
    {

        Vector3 velocity = componentRigidbody.velocity;
        velocity.z = Velocity;
        componentRigidbody.velocity = velocity;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            componentRigidbody.AddForce(Vector3.left * TurnSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            componentRigidbody.AddForce(Vector3.right * TurnSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            componentRigidbody.AddForce(Vector3.forward * Velocity*5 * TurnSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            componentRigidbody.AddForce(Vector3.back * TurnSpeed* Velocity*2);
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "obstacle")
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}