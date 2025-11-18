using Unity.Properties;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] protected int ItemValue {get; set;}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
