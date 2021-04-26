using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadVillages : MonoBehaviour
{
    [SerializeField] private GameObject confirmation;
    [SerializeField] private GameObject Village2Button;
    [SerializeField] private GameObject Village3Button;
    [SerializeField] private GameObject Village4Button;
    private const string village1 = "Village";
    private const string village2 = "Village2";
    private const string village3 = "Village3";
    private const string village4 = "Village4";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(true);
            switch (GameInfo.levelBoss)
            {
                case 1:
                    Village2Button.SetActive(true);
                    break;
                case 2:
                    Village2Button.SetActive(true);
                    Village3Button.SetActive(true);
                    break;
                case 3:
                    Village2Button.SetActive(true);
                    Village3Button.SetActive(true);
                    Village4Button.SetActive(true);
                    break;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(false);
        }
    }

    public void Village1()
    {
        SceneManager.LoadScene(village1, LoadSceneMode.Single);
    }
    public void Village2()
    {
        SceneManager.LoadScene(village2, LoadSceneMode.Single);
    }
    public void Village3()
    {
        SceneManager.LoadScene(village3, LoadSceneMode.Single);
    }
    public void Village4()
    {
        SceneManager.LoadScene(village4, LoadSceneMode.Single);
    }
}
