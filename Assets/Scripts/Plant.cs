using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantData info;

    SetPlantInfo spi;

    private void Start()
    {
        spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    private void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.planeName.text = info.Name;
        spi.threatLevel.text = info.Threat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = info.Icon;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && spi.threatLevel.text == "High")
        {
            PlayerController.dead = true;
        }
    }
}
