using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private float health = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private int armor = 1;
    [SerializeField] private int xp = 0;
    [SerializeField] private float maxHp = 100;

    [SerializeField] private GameObject HealthBar;
    private HeathBarScript hpScript;
    private Slider slider;

    /**private ParticleSystem particles;

    private SpriteRenderer sprite;*/


    public float Health { get => health; }
    public int Damage { get => damage; set => damage = value; }
    public int Armor { get => armor; set => armor = value; }
    public int XP { get => xp; set => xp = value; }
    public float MaxHp { get => maxHp; set => maxHp = value; }

    void Start()
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

}
