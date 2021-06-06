using UnityEngine;

public class AnimBoss : MonoBehaviour
{
    public GameObject bossPanel;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            bossPanel.transform.Translate(100, 0, 0);
            new WaitForSeconds(3);
            bossPanel.transform.Translate(100, 0, 0);
        }
    }
}
