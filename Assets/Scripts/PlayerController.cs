using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    int count;
    float movementX;
    float movementY;
    int totalPickup;
    [SerializeField] float speed = 10;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] Button nextLevelButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        setCountText();
        rb = GetComponent<Rigidbody>();
        totalPickup = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            checkWonSequence();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // destroy player
            Destroy(gameObject);
            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            nextLevelButton.gameObject.SetActive(true);
            nextLevelButton.onClick.AddListener(SceneLoader.ReloadCurrentScene);
            nextLevelButton.GetComponent<TextMeshProUGUI>().text = "Restart Level";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
    void checkWonSequence()
    {
        if (count == totalPickup)
        {
            winText.gameObject.SetActive(true);
            // TODO: make the canvas a prefab, use it in every scene
            // after that every scene will have a nextLevelbutton in it, this will not raise an excpetion
            // Game TODO: add another level with multiple coins
            // add another level with 2 coins and 1 enemy
            // add fall out of world detection (lose)
            // add final level beat (back to main menu)
            // add background music, sound effects on coin pickup, win/lose
            // in options add volume control, mute, change ball skins like tennis, bowling ball, moon

            nextLevelButton.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
        }
    }
}
