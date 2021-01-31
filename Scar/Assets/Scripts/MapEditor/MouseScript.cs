using UnityEngine;
using UnityEngine.EventSystems;

public class MouseScript : MonoBehaviour
{
    public enum LevelManipulation { Create, Rotate, Destroy }; // the possible level manipulation types
    public enum ItemList { Cylinder }; // TODO AJOUTER OBJET A PLACER

    // we hide these to make them known to the rest of the project without them appearing in the Unity editor.
    //TODO AJOUTER OBJET PAR DEFAUT
    //[HideInInspector] public ItemList itemOption = ItemList.Cylinder; // setting the cylinder object as the default object
    
    [HideInInspector] public LevelManipulation manipulateOption = LevelManipulation.Create; // create is the default manipulation type.
    [HideInInspector] public MeshRenderer mr;
    [HideInInspector] public GameObject rotObject;

    public Material goodPlace;
    public Material badPlace;
    //public GameObject Player;
    public ManagerScript ms;

    private Vector3 mousePos;
    private bool colliding;
    private Ray ray;
    private RaycastHit hit;
    
    void Start()
    {
        mr = GetComponent<MeshRenderer>(); // get the mesh renderer component and store it in mr.
    }
    
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(
            Mathf.Clamp(mousePos.x, -30, 30),
            0.75f,
            Mathf.Clamp(mousePos.z, -30, 30)); 

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == 9) 
            {
                colliding = true; 
                mr.material = badPlace; 
            }
            else
            {
                colliding = false;
                mr.material = goodPlace;
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) 
            {
                if (colliding == false && manipulateOption == LevelManipulation.Create) 
                    CreateObject();
                else if (colliding == true && manipulateOption == LevelManipulation.Rotate) 
                    SetRotateObject();
                else if (colliding == true && manipulateOption == LevelManipulation.Destroy)
                {
                    if (hit.collider.gameObject.name.Contains("PlayerModel"))
                        ms.playerPlaced = false;

                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }


    /// <summary>
    /// Object creation
    /// </summary>
    void CreateObject()
    {
        GameObject newObj;

        /*if (itemOption == ItemList.Cylinder) // cylinder
        {
            //Create object
            newObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            newObj.transform.position = transform.position;
            newObj.layer = 9; // set to Spawned Objects layer

            //Add editor object component and feed it data.
            EditorObject eo = newObj.AddComponent<EditorObject>();
            eo.data.pos = newObj.transform.position;
            eo.data.rot = newObj.transform.rotation;
            eo.data.objectType = EditorObject.ObjectType.Cylinder;
        }/*
        else if (itemOption == ItemList.Cube) // cube
        {
            //Create object
            newObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newObj.transform.position = transform.position;
            newObj.layer = 9; // set to Spawned Objects layer

            //Add editor object component and feed it data.
            EditorObject eo = newObj.AddComponent<EditorObject>();
            eo.data.pos = newObj.transform.position;
            eo.data.rot = newObj.transform.rotation;
            eo.data.objectType = EditorObject.ObjectType.Cube;
        }
        else if (itemOption == ItemList.Sphere) // sphere
        {
            //Create object
            newObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newObj.transform.position = transform.position;
            newObj.layer = 9; // set to Spawned Objects layer

            //Add editor object component and feed it data.
            EditorObject eo = newObj.AddComponent<EditorObject>();
            eo.data.pos = newObj.transform.position;
            eo.data.rot = newObj.transform.rotation;
            eo.data.objectType = EditorObject.ObjectType.Sphere;
        }
        else if (itemOption == ItemList.Player) // player start
        {
            if (ms.playerPlaced == false) // only perform next actions if player not yet placed.
            {
                //Create object and give it capsule collider component.
                newObj = Instantiate(Player, transform.position, Quaternion.identity);
                newObj.layer = 9; // set to Spawned Objects layer
                newObj.AddComponent<CapsuleCollider>();
                newObj.GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
                newObj.GetComponent<CapsuleCollider>().height = 2;
                ms.playerPlaced = true;

                //Add editor object component and feed it data.
                EditorObject eo = newObj.AddComponent<EditorObject>();
                eo.data.pos = newObj.transform.position;
                eo.data.rot = newObj.transform.rotation;
                eo.data.objectType = EditorObject.ObjectType.Player;
            }
        }*/
    }

    /// <summary>
    /// Object rotation
    /// </summary>
    void SetRotateObject()
    {
        rotObject = hit.collider.gameObject; // object to be rotated
        ms.rotSlider.value = rotObject.transform.rotation.y; // set slider to current object's rotation.
    }
}
