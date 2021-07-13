using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour {

    string chemin, jsonString;
    public AudioSource audioSrc;
    public Slider slider;
    public Text BoutonJouer;
    public Text BoutonEditMap;
    public Text BoutonOptions;
    public Text BoutonQuitter;
    [SerializeField] TextMeshProUGUI TitleOptions;
    [SerializeField] TextMeshProUGUI TitleLanguage;
    [SerializeField] TextMeshProUGUI LoadSaveTxt;
    [SerializeField] TextMeshProUGUI LoadSaveYes;
    [SerializeField] TextMeshProUGUI LoadSaveNo;

    void Start() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        audioSrc.volume = settings.volume;
        slider.value = settings.volume;
        if(settings.language == "fr") {
            ENToFR();
        } else if(settings.language == "en") {
            FRToEN();
        }
    }

    public void WriteSettings() {

    }  

    public void ReadSettings() {

    }

    public void FRToEN() {
        if(BoutonJouer != null) BoutonJouer.text = "PLAY";
        if(BoutonEditMap != null) BoutonEditMap.text = "MAP EDITOR";
        if(BoutonOptions != null) BoutonOptions.text = "SETTINGS";
        if(BoutonQuitter != null) BoutonQuitter.text = "QUIT";
        if(TitleOptions != null) TitleOptions.text = "SETTINGS";
        if(TitleOptions != null) TitleOptions.text = "SETTINGS";
        if(TitleLanguage != null) TitleLanguage.text = "LANGUAGE";
        if(LoadSaveTxt != null) LoadSaveTxt.text = "A backup is available! Do you want to use it ?";
        if(LoadSaveYes != null) LoadSaveYes.text = "YES";
        if(LoadSaveNo != null) LoadSaveNo.text = "NO";
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "en";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }

    public void ENToFR() {
        if(BoutonJouer != null) BoutonJouer.text = "JOUER";
        if(BoutonEditMap != null) BoutonEditMap.text = "EDITEUR DE MAP";
        if(BoutonOptions != null) BoutonOptions.text = "OPTIONS";
        if(BoutonQuitter != null) BoutonQuitter.text = "QUITTER";
        if(TitleOptions != null) TitleOptions.text = "OPTIONS";
        if(TitleLanguage != null) TitleLanguage.text = "LANGUE";
        if(LoadSaveTxt != null) LoadSaveTxt.text = "Une sauvegarde est disponible! Voulez-vous l'utiliser ?";
        if(LoadSaveYes != null) LoadSaveYes.text = "OUI";
        if(LoadSaveNo != null) LoadSaveNo.text = "NON";
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "fr";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }
}


public class SettingsGame {
    public float volume;
    public string language;
}