using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public InteractionUI objectsenser;
    public GameObject WoodPref;
    public GameObject HardPref;
    public GameObject RockPref;
    public GameObject DiamondPref;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
   

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DeSetActive (GameObject Energy,float DestoryTime)
    {
        yield return null;

        yield return new WaitForSeconds(DestoryTime);
        Energy.SetActive(false);
    }
    


}
