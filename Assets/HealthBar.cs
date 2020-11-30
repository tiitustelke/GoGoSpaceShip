using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Updates the healthbar
/// </summary>
public class HealthBar : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerInfo.health;
    }
}
