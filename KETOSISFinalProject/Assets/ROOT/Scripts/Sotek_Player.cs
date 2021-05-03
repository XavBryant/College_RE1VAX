using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Sotek_Player : MonoBehaviour
{
    public int CurrentDay;
    public int NRGActivity;
    public int PHealthValue;
    public int PFoodValue;
    public float PFatValue;
    public float PMetabolism;
    public bool inKetosis;

    // public float PWeight;

    //Status Display
    public TextMeshProUGUI EnergyStatus;
    public TextMeshProUGUI HealthStatus;
    public TextMeshProUGUI FoodStatus;
    public TextMeshProUGUI FatStatus;
    public TextMeshProUGUI MetabolismStatus;
    public TextMeshProUGUI KetosisStatus;

    public TextMeshProUGUI TheDay;

    public GameObject ErrorPanel;

    public bool Healed;


    // Sotek Player Model
    public GameObject SotekStage1;
    public GameObject SotekStage2;
    public GameObject SotekStage3;



    // Start is called before the first frame update
    void Start()
    {
        //initialize player values
        CurrentDay = 1;
        NRGActivity = 3;
        PHealthValue = 10;
        PFoodValue = 20;
        PFatValue = 300;
        PMetabolism = 30;
        inKetosis = false;

        StatusUpdate();
    }


    public void CheckNRG() {
        if (NRGActivity == 0)
        {
            NextInterval();
        }
        else {
            return; 
       }
    }

    public void NextInterval() {

        

    if (PMetabolism >= 30) {
            inKetosis = true;
    }

        if (inKetosis == false)
        {
            PFatValue -= 20;
        }

        if (inKetosis == true) {
     PFatValue -= (PMetabolism - 20);
    }
        else { }


        if (PFatValue > 250) {
            SotekStage1.gameObject.SetActive(false);
            SotekStage2.gameObject.SetActive(true);
            SotekStage3.gameObject.SetActive(false);
        }

        if (PFatValue > 200) {
            SotekStage1.gameObject.SetActive(false);
            SotekStage2.gameObject.SetActive(false);
            SotekStage3.gameObject.SetActive(true);
        }

        PMetabolism -= 10;

        NRGActivity += 3;
        CurrentDay += 1;
        StatusUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EatFood() {
        NRGActivity -= 1;
        inKetosis = false;
        PFoodValue += 10;
        StatusUpdate();
    }

    public void SotekActivity(int num) {
        if (PFoodValue <= 0) {
            ErrorPanel.SetActive(true);
            return;
        }
        SpendNRGActivity();
        if (num == 1) { PMetabolism += 5; PFoodValue -= 10; }
        if (num == 2) { PMetabolism += 10; PFoodValue -= 15; }
        if (num == 3) { PMetabolism += 15; PFoodValue -= 20; }
        StatusUpdate();
    }


    public void SpendNRGActivity() {

        if (NRGActivity <= 0) {
            ErrorPanel.SetActive(true);
            return;
        }
        
        NRGActivity -= 1;
    }




    public void StatusUpdate() {
        //used to update Sotek player UI stats
        TheDay.text = "Day " + CurrentDay.ToString();
        EnergyStatus.text = "Current Energy: " + NRGActivity.ToString();
        HealthStatus.text = "Current Health: " + PHealthValue.ToString();
        FoodStatus.text = "Food Status: " + PFoodValue.ToString();
        FatStatus.text = "Fat Value: " + PFatValue.ToString();
        MetabolismStatus.text = "Metabolism: " + PMetabolism.ToString();
        KetosisStatus.text = "In Ketosis: " + inKetosis.ToString();

        ErrorPanel.SetActive(false);
        CheckNRG();
}

}
