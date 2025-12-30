using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    int count;
    float movementX;
    float movementY;
    int totalPickup;
    public float GROUND_LIMIT = -5f;
    [SerializeField] float speed = 10;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] Button nextLevelButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        totalPickup = GameObject.FindGameObjectsWithTag("PickUp").Length;
        rb = GetComponent<Rigidbody>();
        setCountText();
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
            AudioSource PickUpAudio = gameObject.gameObject.GetComponent<AudioSource>();
            PickUpAudio.Play();
            count++;
            other.gameObject.SetActive(false);
            setCountText();
            checkWonSequence();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LostSequence();
        }
    }

    private void LostSequence()
    {
        // destroy player
        Destroy(gameObject);
        TextMeshProUGUI message = winText.GetComponent<TextMeshProUGUI>();
        message.text = "You Lose!";
        message.color = new Color32(210, 0, 0, 255);

        winText.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
        nextLevelButton.onClick.AddListener(SceneLoader.ReloadCurrentScene);
        nextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = "Restart Level";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < GROUND_LIMIT)
        {
            LostSequence();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void setCountText()
    {
        Debug.Log("count set");
        countText.text = "Coins: " + count.ToString() + " / " + totalPickup;
    }
    void checkWonSequence()
    {
        if (count == totalPickup)
        {
            winText.gameObject.SetActive(true);
            // Game TODO: add another level with multiple coins
            // add another level with 2 coins and 1 enemy
            // add parkor level, that need to be precise (maybe 1 jumpers, mostly turns and falling to other platforms)
            // add jump pad, launch to ball like 10f in the air, can be used for parkor and jumb above walls
            // lock/key thing? might need some assets for that
            // procuderal generaion levels? maybe after game is beat
            // add final level beat (back to main menu)
            // add background music, sound effects on coin pickup, win/lose
            // in options add volume control, mute, change ball skins like tennis, bowling ball, moon

            nextLevelButton.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
        }
    }
}
