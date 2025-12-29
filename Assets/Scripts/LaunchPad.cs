using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    float JUMP_HIGHT = 20.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        bool shouldLaunch = collision.gameObject.tag == "Player"; // add enemey later maybe
        Debug.Log("in OnCollisionEnter: " + collision.gameObject.tag);
        Debug.Log("shouldLaunch: " + shouldLaunch);
        if (!shouldLaunch) return;
        // Try to get the Rigidbody component from the collided GameObject
        Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>();
        if (playerRB != null)
        {
            playerRB.AddForce(Vector3.up * JUMP_HIGHT, ForceMode.Impulse);
        }
    }
}