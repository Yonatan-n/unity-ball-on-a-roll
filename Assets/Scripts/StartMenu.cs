using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGameHandler);
        optionsButton.onClick.AddListener(OptionsHandler);
        exitButton.onClick.AddListener(ExitGameHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGameHandler()
    {
        Debug.Log("starting game");
        SceneLoader.LoadNextScene();
    }

    public void OptionsHandler()
    {
        Debug.Log("options");
    }
    public void ExitGameHandler()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
