using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDecor : MonoBehaviour
{
    public GameObject marecage;
    public GameObject arene;
    public GameObject cimetiere;
    

    void Start()
    {
        Scene scene = EditorSceneManager.GetActiveScene();
        if(scene.name == "Main")
        {
            marecage.SetActive(true);
        }
        else
        {
            marecage.SetActive(false);
        }

        if (scene.name == "Donjon2")
        {
            arene.SetActive(true);
        }
        else
        {
            arene.SetActive(false);
        }

        if (scene.name == "Donjon4")
        {
            cimetiere.SetActive(true);
        }
        else
        {
            cimetiere.SetActive(false);
        }
        if(scene.name == "DonjonEditMap") {
            arene.SetActive(true);
        } else {
            arene.SetActive(false);
        }
    }
}
