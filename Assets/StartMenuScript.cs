using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] private Button start;
    [SerializeField] private Button exit;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);

    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
