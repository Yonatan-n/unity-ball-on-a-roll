using UnityEngine;
using UnityEngine.UI;


public class Victory : MonoBehaviour
{
    [SerializeField] Button backToMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backToMenu.onClick.AddListener(backToStart);
    }
    void backToStart()
    {
        SceneLoader.LoadSceneByIndex(0);
    }
    // Update is called once per frame
    void Update()
    {

    }
}