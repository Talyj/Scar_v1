using UnityEngine;
using UnityEngine.UI;

public class ActifRaffale : MonoBehaviour
{
    public Image manaa;
    public static float currentMana = 200;
    public static float maxMana = 200;

    void Start()
    {
        //Fais en sorte que la barre de mana ne deborde pas de son encoche
        if (currentMana <= 0)
        {
            currentMana = 0;
        }

        if (currentMana >= 200)
        {
            currentMana = 200;
        }

    }

    void Update()
    {
        //Update la barre de mana
        manaa.fillAmount = currentMana / maxMana;
        currentMana += 2 * Time.deltaTime;
    }
}
