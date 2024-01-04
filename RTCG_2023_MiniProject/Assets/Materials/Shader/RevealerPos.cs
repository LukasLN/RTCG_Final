using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealerPos : MonoBehaviour
{
    Vector3 playerPos;

    Material objectMaterial;
    [SerializeField] Transform RevealerObjectTransform;

    int isABActive;

    // Start is called before the first frame update
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        playerPos = RevealerObjectTransform.position;

        // Set the shader property
        objectMaterial.SetVector("_LanternPos", playerPos);

        if(AbState.isAbActive == false)
        {
            isABActive = 0;
            objectMaterial.SetInt("_isAbilityActive", isABActive);
            //Debug.Log("AbState false");
        }
        else
        {
            isABActive = 1;
            objectMaterial.SetInt("_isAbilityActive", isABActive);
            //Debug.Log("AbState true");
        }
    }
    
}
