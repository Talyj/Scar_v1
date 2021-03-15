using UnityEngine;

public class SwitchCartes : MonoBehaviour
{
    [SerializeField] public GameObject Shield2;
    public Transform spawnShield;
    public void SwitchShield()
    {
        Destroy(gameObject);
        Instantiate<GameObject>(Shield2, spawnShield);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
