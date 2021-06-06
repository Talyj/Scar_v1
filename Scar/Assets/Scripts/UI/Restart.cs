using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UIElements;

public class Restart : MonoBehaviour
{
    public string scene;
    public string scene2;
    public GameObject panel;
    private bool active;
    public GameObject panel2;
    [SerializeField] private AmountBoard amountBoard;
    private string chemin, jsonString;

    public void Reload(int choice)
    {
        if(choice == 0)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        else if(choice == 1)
        {
            SceneManager.LoadScene(scene2, LoadSceneMode.Single);
        }
    }

    public void loadScene()
    {
        chemin = Application.streamingAssetsPath + "/inventory.json";
        jsonString = File.ReadAllText(chemin);
        VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
        inventaire.amount_piece = amountBoard.amount_piece;
        inventaire.amount_rubis = amountBoard.amount_rubis;
        inventaire.amount_slot_1 = amountBoard.amount_slot_1;
        inventaire.amount_slot_2 = amountBoard.amount_slot_2;
        inventaire.amount_slot_3 = amountBoard.amount_slot_3;
        inventaire.amount_slot_card = amountBoard.amount_slot_card;
        inventaire.amount_slot_hotbar = amountBoard.amount_slot_hotbar;
        inventaire.hotbar_type = amountBoard.hotbar_type;
        inventaire.slot1_type = amountBoard.slot1_type;
        inventaire.slot2_type = amountBoard.slot2_type;
        inventaire.slot3_type = amountBoard.slot3_type;
        inventaire.slotcard_type = amountBoard.slotcard_type;
        jsonString = JsonUtility.ToJson(inventaire);
        File.WriteAllText(chemin, jsonString);

        SceneManager.LoadScene(scene);
    }

    public void Continue()
    {   
        chemin = Application.streamingAssetsPath + "/inventory.json";
        jsonString = File.ReadAllText(chemin);
        VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
        inventaire.amount_piece = 0;
        inventaire.amount_rubis = 0;
        inventaire.amount_slot_1 = 0;
        inventaire.amount_slot_2 = 0;
        inventaire.amount_slot_3 = 0;
        inventaire.amount_slot_card = 0;
        inventaire.amount_slot_hotbar = 0;
        inventaire.hotbar_type = "";
        inventaire.slot1_type = "";
        inventaire.slot2_type = "";
        inventaire.slot3_type = "";
        inventaire.slotcard_type = "";
        jsonString = JsonUtility.ToJson(inventaire);
        File.WriteAllText(chemin, jsonString);
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Activate(int choice)
    {
        if (choice == 0)
        {
            if (active)
            {
                panel2.SetActive(false);
                active = false;
            }
            else
            {
                panel2.SetActive(true);
                active = true;
            }    
        }
        else if (choice == 1)
        {
            if (active)
            {
                panel2.SetActive(false);
                active = false;
            }
            else
            {
                panel2.SetActive(true);
                active = true;
            }
        }
        
    }
}
