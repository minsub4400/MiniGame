using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoding : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider loding;
    private float maxTime = 3f;
    private float elaspedTime;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

        Loding();
    }

    public void Loding()
    {

            elaspedTime += Time.deltaTime;
            loding.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
            if (elaspedTime >= maxTime)
            {
                elaspedTime = 0f;
                loding.value = 1f;
                gameObject.SetActive(false);
            IntertionUi.InteractionOn = false;
            } 
    }
}
