using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    private bool menuActive;
    private Canvas canvas;

    private TextMeshProUGUI[] opts;

    private string[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        menuActive = false;


        canvas = GameObject.Find("levelUpMenu").GetComponent<Canvas>();
        canvas.enabled = false;
        weapons = new string[]{
            "Whip","Garlic","Wand"
        };
        opts = canvas.GetComponentsInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.L) && !menuActive)
        {
            //LEÁLL
            Time.timeScale = 0f;
            menuActive = true;
            canvas.enabled = menuActive;
        }
        else if (Input.GetKeyDown(KeyCode.L) && menuActive)
        {
            //TOVÁBB
            Time.timeScale = 1f;
            menuActive = false;
            canvas.enabled = menuActive;
        }
        */
    }

    public void levelUp()
    {
        Time.timeScale = 0f;
        menuActive = true;
        canvas.enabled = menuActive;

        for (int i = 0; i < opts.Length; i++)
        {
            opts[i].text = weapons[i];
        }
    }


}
