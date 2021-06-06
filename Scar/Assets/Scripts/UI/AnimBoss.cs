using UnityEngine;

public class AnimBoss : MonoBehaviour
{
    public GameObject bossPanel;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            bossPanel.SetActive(true);
            new WaitForSeconds(3);
            bossPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
