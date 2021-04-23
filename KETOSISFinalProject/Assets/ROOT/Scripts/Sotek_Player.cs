using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int NRGActivity;
    public int PHealthValue;
    public int PFoodValue;
    public float PFatValue;
    public float PMetabolism;
    public bool inKetosis;

    // public float PWeight;

    //Status Display
    public GameObject EnergyStatus;
    public GameObject HealthStatus;
    public GameObject FoodStatus;
    public GameObject FatStatus;
    public GameObject MetabolismStatus;
    public GameObject KetosisStatus;

    public GameObject ErrorPanel;

    public bool Healed;



    // Start is called before the first frame update
    void Start()
    {
        //initialize player values
        NRGActivity = 3;
        PHealthValue = 10;
        PFoodValue = 20;
        PFatValue = 20;
        PMetabolism = 30;
        inKetosis = false;
    }


    public void NextInterval() {
        PMetabolism -= 10;

        if (PMetabolism >= 30) {
            inKetosis = true;
        }

            if (inKetosis == true) {
                _ = PFatValue - (PMetabolism / 1.3);
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplaySotekStats() { 
    //used to update Sotek player UI stats
    
    }


    public void EatFood() {
        NRGActivity -= 1;
        inKetosis = false;
        PFoodValue += 10;
    }

    public void SotekActivity(int num) {
        NRGActivity -= 1;
        if (num == 1) { PMetabolism += 5; PFoodValue -= 10; }
        if (num == 2) { PMetabolism += 10; PFoodValue -= 15; }
        if (num == 3) { PMetabolism += 15; PFoodValue -= 20; }    
    }


    public void SpendNRGActivity() {

        if (NRGActivity <= 0) {
            ErrorPanel.SetActive(true);
            return;
        }
        
        NRGActivity -= 1;
        EnergyStatus = NRGActivity; 

    }




    public void UpdateMetabolism(int MRate) { 
    //called to update metabolism


    }
}
