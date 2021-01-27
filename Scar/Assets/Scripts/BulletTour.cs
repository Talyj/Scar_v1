using UnityEngine;

public class BulletTour : MonoBehaviour
{
    private Transform target;

    public float speed = 30f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        //if (target == null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //Vector3 dir = target.position - transform.position;
        //float distanceThisFrame = speed * Time.deltaTime;

        //if (dir.magnitude <= distanceThisFrame)
        //{
        //    HitTarget();
        //    return;
        //}

        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);


    }

    void HitTarget ()
    {
        Debug.Log("ME HIT SOMETHING");
    }

}
