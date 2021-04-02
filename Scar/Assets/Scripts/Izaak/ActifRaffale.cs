using UnityEngine;
using UnityEngine.UI;

public class ActifRaffale : MonoBehaviour
{
    [SerializeField] private int numBullets;
    [SerializeField] private BulletController bullet;
    public float bulletSpeed;
    private float radius = 1;

    public Image manaa;
    public float currentMana = 200;
    public float maxMana = 200;

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

        if(GameObject.FindGameObjectWithTag("Actif"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && currentMana >= 50)
            {
                CircleShoot();
                PlayerController.numberBullets += numBullets;
                currentMana -= 50;
            }
        }
     
    }

    void CircleShoot()
    {
        for (int i = 0; i < numBullets; i++)
        {
            // Determine la position de spawn des balles
            BulletController newBullet = Instantiate(bullet, gameObject.transform.position + Vector3.up * radius, new Quaternion(0, 0, 0, 0)) as BulletController;
            newBullet.speed = bulletSpeed;
            // Modifie la manière de spawn des balles (ici en cercle)
            newBullet.transform.RotateAround(gameObject.transform.position, Vector3.up, 360 / (float)numBullets * i);
        }
    }
}
