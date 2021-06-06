using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationsForEditMap : MonoBehaviour
{
    public string typeSalle = "null";
    public int numberPat = 0;
    public int numberPit = 0;
    public int numberPot = 0;
    public int numberPut = 0;
    [SerializeField]private GameObject salle1;
    [SerializeField]private GameObject salle2;
    [SerializeField]private GameObject salle3;
    [SerializeField]private GameObject salle4;
    [SerializeField]private GameObject salle5;
    [SerializeField]private GameObject inputField1;
    [SerializeField]private GameObject inputField2;
    [SerializeField]private GameObject inputField3;
    [SerializeField]private GameObject inputField4;

    public void ActivateSalle(string salle) {
        if(salle == "salle1") {
            salle1.SetActive(true);
            salle2.SetActive(false);
            salle3.SetActive(false);
            salle4.SetActive(false);
            salle5.SetActive(false);
            typeSalle = "salle1";
        } else if(salle == "salle2") {
            salle1.SetActive(false);
            salle2.SetActive(true);
            salle3.SetActive(false);
            salle4.SetActive(false);
            salle5.SetActive(false);
            typeSalle = "salle2";
        } else if(salle == "salle3") {
            salle1.SetActive(false);
            salle2.SetActive(false);
            salle3.SetActive(true);
            salle4.SetActive(false);
            salle5.SetActive(false);
            typeSalle = "salle3";
        } else if(salle == "salle4") {
            salle1.SetActive(false);
            salle2.SetActive(false);
            salle3.SetActive(false);
            salle4.SetActive(true);
            salle5.SetActive(false);
            typeSalle = "salle4";
        } else if(salle == "salle5") {
            salle1.SetActive(false);
            salle2.SetActive(false);
            salle3.SetActive(false);
            salle4.SetActive(false);
            salle5.SetActive(true);
            typeSalle = "salle5";
        }
    }

    public void GetNumberOfEnemy() {
        numberPat = int.Parse(inputField1.GetComponent<TMP_InputField>().text);
        numberPit = int.Parse(inputField2.GetComponent<TMP_InputField>().text);
        numberPot = int.Parse(inputField3.GetComponent<TMP_InputField>().text);
        numberPut = int.Parse(inputField4.GetComponent<TMP_InputField>().text);
    }
}
