using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AbilityCon : MonoBehaviour
{
    bool abilityState = false;
    bool WaitForAbility = false;
    [SerializeField] List<GameObject> listOfTransparentObejcts = new List<GameObject>();
    [SerializeField] GameObject fps_Cam;

    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _FullScreenEffect;
    [SerializeField] private Material GhostMat;


    // Start is called before the first frame update
    void Start()
    {
        _FullScreenEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWorldState();
        AbilityState();
    }

    void ChangeWorldState()
    {
        if (Input.GetKeyDown(KeyCode.Space) && WaitForAbility == false && AbState.isAbActive == true)
        {
            StartCoroutine(WaitAndTP());
            StartCoroutine(fps_Cam.GetComponent<FPS_Cam>().Shake(2f, 0.05f));
        }
    }

    void AbilityState()
    {

        if (Input.GetKeyDown(KeyCode.E) && WorldState.isOverWorldInFocus == false)
        {
            if (AbState.isAbActive == true)
            {
                for (int i = 0; i > listOfTransparentObejcts.Count; i++)
                {
                    listOfTransparentObejcts[i].SetActive(false);
                    
                }
                Debug.Log("abilityState = false");
                listOfTransparentObejcts[0].SetActive(false);
                _FullScreenEffect.SetActive(false);
                AbState.isAbActive = false;
            }
            else if (AbState.isAbActive == false)
            {
                for (int i = 0; i > listOfTransparentObejcts.Count; i++)
                {
                    listOfTransparentObejcts[i].SetActive(true);
                   
                }
                Debug.Log("abilityState = true");
                listOfTransparentObejcts[0].SetActive(true);
                _FullScreenEffect.SetActive(true);
                AbState.isAbActive = true;
            }

        }
    }


    private IEnumerator WaitAndTP()
    {

        yield return new WaitForSeconds(2);

        if (WorldState.isOverWorldInFocus == true)
        {
            this.transform.position = this.transform.position + new Vector3(13.24f, 0f, 0f);
            WorldState.isOverWorldInFocus = false;
        }
        else
        {
            this.transform.position = this.transform.position - new Vector3(13.24f, 0f, 0f);
            WorldState.isOverWorldInFocus = true;
        }

        Debug.Log("WorldState = " + WorldState.isOverWorldInFocus);

        yield return new WaitForSeconds(0.5f);
        WaitForAbility = false;
    }
}
