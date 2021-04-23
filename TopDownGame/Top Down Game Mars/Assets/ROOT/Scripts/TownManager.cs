using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TownManager : MonoBehaviour
{
    public GameObject BuildingDisplayPanel;
    public GameObject PurchaseDisplayPanel;
    public TextMeshProUGUI BuildingNameText;
    public TextMeshProUGUI BuildingValueText;
    public TextMeshProUGUI BuildingGoldCost;
    public TextMeshProUGUI BuildingHydrationCost;
    public TextMeshProUGUI BuildingSilverCost;
    public LayerMask BlayerMask;

    private Camera cam;

    private Building selectedBuilding;

    [SerializeField]
    private CurrencyCost CurrentCurrency;

    public TextMeshProUGUI GoldDisplay;
    public TextMeshProUGUI SilverDisplay;
    public TextMeshProUGUI WaterDisplay;

    public bool Running = true;
    public float DaytimeLength;
    private float DayTimeTimer;

    public List<Building> buildings = new List<Building>();




    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        SetCurrency();
    }


    void SetCurrency() {
        GoldDisplay.text = CurrentCurrency.GoldValue.ToString();
        SilverDisplay.text = CurrentCurrency.SilverValue.ToString();
        WaterDisplay.text = CurrentCurrency.WaterValue.ToString();
    }



    // Update is called once per frame
    void Update()
    {


        if (Running) {

            DayTimeTimer -= Time.deltaTime;
            if (DayTimeTimer <= 0) {
                DailyTally();
                DayTimeTimer = DaytimeLength;
            }
        }





        if (Input.GetButtonUp("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, BlayerMask))
            {
                Debug.Log("We hit " + hit.collider.gameObject);
                if (selectedBuilding == null)
                {
                    selectedBuilding = hit.collider.GetComponent<Building>();
                    selectedBuilding.SetSelectionCube(true);

                }
                else
                {
                    selectedBuilding.SetSelectionCube(false);
                    selectedBuilding = hit.collider.GetComponent<Building>();
                    selectedBuilding.SetSelectionCube(true);
                }
                ShowBuildingInfo();




            }
            else
            {
                Debug.Log("We did not hit anything");
                Debug.DrawLine(ray.origin, ray.direction * 10, Color.black, 5f);
            }

        }
        else if (Input.GetButtonUp("Fire2")) {
            if (selectedBuilding != null)
            DeselectBuilding();
        }
    }


    void DailyTally() {


        foreach (var building in buildings) {
            building.DoProduction(this);
        }
        SetCurrency();

    }


    public void AddGold(int val) {
        CurrentCurrency.GoldValue += val;
    }

    public void AddSilver(int val)
    {
        CurrentCurrency.SilverValue += val;
    }

    public void AddWater(int val)
    {
        CurrentCurrency.WaterValue += val;
    }


    public void DeselectBuilding() {
        BuildingDisplayPanel.SetActive(false);
        selectedBuilding.SetSelectionCube(false);
        selectedBuilding = null;
    }


    public void ShowBuildingInfo() {
        BuildingDisplayPanel.SetActive(true);
        BuildingNameText.text = selectedBuilding.BName;
        ///BuildingValueText.text = selectedBuilding.GetBValue().ToString();
        BuildingGoldCost.text = selectedBuilding.GetGoldUpgradeCost().ToString();
        BuildingHydrationCost.text = selectedBuilding.GetHydrationUpgradeCost().ToString();
        BuildingSilverCost.text = selectedBuilding.GetSilverUpgradeCost().ToString();
    }

    public void AttemptPurchase() {
        if (selectedBuilding != null) {

            bool canAfford = true;
            if (CurrentCurrency.GoldValue < selectedBuilding.GetGoldUpgradeCost()) 
            {
                canAfford = false;
                print("cannot afford gold");
            }
            if (CurrentCurrency.WaterValue < selectedBuilding.GetHydrationUpgradeCost())
            {
                canAfford = false;
                print("cannot afford water");
            }
            if (CurrentCurrency.SilverValue < selectedBuilding.GetSilverUpgradeCost())
            {
                canAfford = false;
                print("cannot afford silver");
            }



            if (!canAfford) {
                PurchaseDisplayPanel.SetActive(true);
            }
            else {
                // do upgrade

                print("Do upgrade");
                CurrentCurrency.GoldValue -= selectedBuilding.GetGoldUpgradeCost();
                CurrentCurrency.WaterValue -= selectedBuilding.GetHydrationUpgradeCost();
                CurrentCurrency.SilverValue -= selectedBuilding.GetSilverUpgradeCost();
                selectedBuilding.UpgradeBuilding();
                SetCurrency();
            }

        }
    }

}

[Serializable]
public struct CurrencyCost {
    public int GoldValue;
    public int SilverValue;
    public int WaterValue;
}