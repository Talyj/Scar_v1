using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SlidesManager : MonoBehaviour
{
    string chemin, jsonString;
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;
    public GameObject slideWin;
    public GameObject slideRemerciements;
    [SerializeField] TextMeshProUGUI textSlide1;
    [SerializeField] TextMeshProUGUI textSlide2;
    [SerializeField] TextMeshProUGUI textSlide3;
    [SerializeField] TextMeshProUGUI textSlide4;
    [SerializeField] TextMeshProUGUI textSlideWin;

    void Start()
    {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(settings.language == "fr") {
            ENToFR();
        } else if(settings.language == "en") {
            FRToEN();
        }

        if(settings.slides == 0) {
            Slide1();
        } else if(settings.slides == 2) {
            SlideWin();
        }
    }

    public void FRToEN() {
        if(textSlide1 != null) textSlide1.text = "As a child, Izaak lived in a village in the middle of a forest, being protected by brigants against possible attacks in exchange for rubies. \nOne day..";
        if(textSlide2 != null) textSlide2.text = "Three heroes came to eliminate these brigants, thinking thus to save the village of Izaak. \nHowever, they did the complete opposite..";
        if(textSlide3 != null) textSlide3.text = "Without the protection of these brigands, the village ends up being attacked and destroyed. \nPutting the blame on these three heroes..";
        if(textSlide4 != null) textSlide4.text = "Izaak vowed to pursue them and avenge his village... ";
        if(textSlideWin != null) textSlideWin.text = "After a long and hard journey, Izaak ends up getting his hands on these heroes. \nFilled with hatred, he will eventually kill the three, avenging his native village.";
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "en";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }

    public void ENToFR() {
        if(textSlide1 != null) textSlide1.text = "Enfant, Izaak vivait dans un village au beau milieu d'une foret, etant protege par des brigants contre d'eventuels attaques en echange de rubis. \nUn beau jour...";
        if(textSlide2 != null) textSlide2.text = "Trois heros vinrent elimines ces brigants, pensant ainsi sauver le village d'Izaak. \nCependant, ils firent totalement le contraire...";
        if(textSlide3 != null) textSlide3.text = "Sans la protection de ces brigands, le village finit par etre attaque et detruit. \nMettant la faute sur ces trois heros..";
        if(textSlide4 != null) textSlide4.text = "Izaak se jura de les poursuivre et de venger son village... ";
        if(textSlideWin != null) textSlideWin.text = "Apres un long et dur voyage, Izaak finit par mettre la main sur ces héros. \nRempli de haine, il finira par tuer les trois, vengeant selon lui son village natale.";
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "fr";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }

    public void Slide1() {
        slide1.SetActive(true);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
        slideWin.SetActive(false);
        slideRemerciements.SetActive(false);
    }

    public void Slide1To2() {
        slide1.SetActive(false);
        slide2.SetActive(true);
        slide3.SetActive(false);
        slide4.SetActive(false);
        slideWin.SetActive(false);
        slideRemerciements.SetActive(false);
    }

    public void Slide2To3() {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(true);
        slide4.SetActive(false);
        slideWin.SetActive(false);
        slideRemerciements.SetActive(false);
    }

    public void Slide3To4() {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(true);
        slideWin.SetActive(false);
        slideRemerciements.SetActive(false);
    }

    public void Slide4ToPlay() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.slides = 1;
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
        SceneManager.LoadScene("Village");
    }

    public void SlideWin() {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
        slideWin.SetActive(true);
        slideRemerciements.SetActive(false);
    }

    public void SlideWinToRemerciement() {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
        slideWin.SetActive(false);
        slideRemerciements.SetActive(true);
    }

    public void Finish() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.slides = 3;
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
        SceneManager.LoadScene("Village4");
    }
}
