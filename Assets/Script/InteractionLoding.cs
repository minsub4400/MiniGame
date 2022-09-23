using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoding : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider loding;
    private float elaspedTime;
    public InteractionUI Energy;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        Loding(Energy.lt);
        
    }

    public void Loding(float maxTime)
    {
            
            elaspedTime += Time.deltaTime;
            loding.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
            _animator.SetBool("Attack", true);
            if (elaspedTime >= maxTime)
            {
            Energy.gameObject.SetActive(false);
            _animator.SetBool("Attack", false);
            elaspedTime = 0f;
                loding.value = 1f;
                gameObject.SetActive(false);
            IntertionUi.InteractionOn = false;
            } 
    }
   
}
