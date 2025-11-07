using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    public void updateHealthBar(float health)
    {
        slider.value = health;
    }
}
