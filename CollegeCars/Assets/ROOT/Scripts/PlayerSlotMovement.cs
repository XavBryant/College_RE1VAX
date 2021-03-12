using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlotMovement : MonoBehaviour
{

    public int CurrentPosition = 1;
    public float speed;
    public bool RightInput;
    public bool LeftInput;
    private int position;
    public GameObject LoseText;
    public GameObject WinText;
    public GameObject Player;
    public GameObject OtherCamera;
    public bool GameActive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameActive == true) { 
        // constantly move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

        //
        RightInput = Input.GetKeyDown(KeyCode.D);
        LeftInput = Input.GetKeyDown(KeyCode.A);

        //
        if (RightInput == true && LeftInput != true)
        {
            Debug.Log("Key was pressed.");
            switch (CurrentPosition)
            {
                case 1:
                    CurrentPosition = 2;
                    ChangePosition(2);
                    break;
                case 2:
                    CurrentPosition = 3;
                    ChangePosition(3);
                    break;
                case 3:
                    CurrentPosition = 4;
                    ChangePosition(4);
                    break;
                case 4:
                    CurrentPosition = 5;
                    ChangePosition(5);
                    break;
                case 5:
                    CurrentPosition = 1;
                    ChangePosition(1);
                    break;
            }
        }

        if (LeftInput == true && RightInput != true)
        {
            Debug.Log("Key was pressed.");
            switch (CurrentPosition)
            {
                case 1:
                    CurrentPosition = 5;
                    ChangePosition(5);
                    break;
                case 2:
                    CurrentPosition = 1;
                    ChangePosition(1);
                    break;
                case 3:
                    CurrentPosition = 2;
                    ChangePosition(2);
                    break;
                case 4:
                    CurrentPosition = 3;
                    ChangePosition(3);
                    break;
                case 5:
                    CurrentPosition = 4;
                    ChangePosition(4);
                    break;
            }
        }
    }



        private void ChangePosition(int position)
        {
            if (position == 1) { transform.position = new Vector3(0, 20, transform.position.z); };
            if (position == 2) { transform.position = new Vector3(10, 16, transform.position.z); };
            if (position == 3) { transform.position = new Vector3(4, 10, transform.position.z); };
            if (position == 4) { transform.position = new Vector3(-4, 10, transform.position.z); };
            if (position == 5) { transform.position = new Vector3(-10, 16, transform.position.z); };
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("HIT");
            LoseText.SetActive(true);
            GameActive = false;
            Player.SetActive(false);
            OtherCamera.SetActive(true);
        }


        if (other.gameObject.tag == "Finish") {
            WinText.SetActive(true);
            GameActive = false;
            Player.SetActive(false);
            OtherCamera.SetActive(true);
        }
    }
}