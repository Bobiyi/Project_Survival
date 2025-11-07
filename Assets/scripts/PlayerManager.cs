using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private float health = 100;
    [SerializeField] private float damage = 10;
    [SerializeField] private int armor = 1;
    [SerializeField] private int xp = 0;
    [SerializeField] private float maxHp = 100;

    [SerializeField] private GameObject HealthBar;
    private HeathBarScript hpScript;
    private Slider slider;

    [SerializeField] private GameObject DamageText_Canvas;
    private Text DamageText;

    /**private ParticleSystem particles;

    private SpriteRenderer sprite;*/


    public float Health { get => health; }
    public float Damage { get => damage; }
    public int Armor { get => armor; set => armor = value; }
    public int XP { get => xp; set => xp = value; }
    public float MaxHp { get => maxHp; set => maxHp = value; }

    void Start()
    {
        setSlider();

        DamageText = GameObject.FindAnyObjectByType<Text>();

        DamageText.text = Damage.ToString();

        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetDamage(10);
        }
    }

    private void setSlider()
    {
        health = maxHp;

        HealthBar = GameObject.FindGameObjectWithTag("HealthBar");

        hpScript = HealthBar.GetComponent<HeathBarScript>();

        slider = HealthBar.GetComponent<Slider>();

        slider.maxValue = MaxHp;

        slider.value = Health;
    }

    public void TakeDamage(float damageTaken)
    {
        //sprite.color = Color.red;

        health = Health - (damageTaken - armor);

        hpScript.updateHealthBar(Health);

        Debug.Log("Damage recieved", this);
    }

    [ContextMenu("Add damage")]
    public void SetDamage(float damageToAdd)
    {
        damage += damageToAdd;

        DamageText.text = damageToAdd.ToString();
    }

}
