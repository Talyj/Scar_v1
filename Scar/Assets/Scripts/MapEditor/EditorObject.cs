using UnityEngine;
using System;

public class EditorObject : MonoBehaviour 
{
    public enum ObjectType {}; // the different objects this could be attached to.

    [Serializable]
    public struct Data
    {
        public Vector3 pos; 
        public Quaternion rot; 
        public ObjectType objectType;
    }

    public Data data; // public reference to Data
}
