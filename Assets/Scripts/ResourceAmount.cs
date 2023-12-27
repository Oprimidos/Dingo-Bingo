using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceAmount : MonoBehaviour
{
    public TextMeshProUGUI stoneAmount;
    public TextMeshProUGUI ironAmount;
    public TextMeshProUGUI goldAmount;

    public  int stoneNum = 200;
    public  int ironNum = 0;
    public  int goldNum = 0;

    public int stoneNumR = 400;
    public int ironNumR = 50;
    public int goldNumR = 0;

    public GameManagement gameManagement;
    // Start is called before the first frame update
    void Start()
    {
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        //resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagement.playerNum == 1)
        {
        //Debug.Log(stoneNum + " and " + ironNum + " and " + goldNum);
        stoneAmount.text = stoneNum.ToString();
        ironAmount.text = ironNum.ToString();
        goldAmount.text = goldNum.ToString();
        }else if(gameManagement.playerNum == 2)
        {
            //Debug.Log(stoneNumR + " and " + ironNumR + " and " + goldNumR);
            stoneAmount.text = stoneNumR.ToString();
            ironAmount.text = ironNumR.ToString();
            goldAmount.text = goldNumR.ToString();
        }
        
    }
}