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
    public static int ironNum = 0;
    public static int goldNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        //resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stoneNum + " and " + ironNum + " and " + goldNum);
        stoneAmount.text = stoneNum.ToString();
        ironAmount.text = ironNum.ToString();
        goldAmount.text = goldNum.ToString();
    }
}