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

    public int stoneNum=100;
    public int ironNum=0;
    public int goldNum=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stoneAmount.text = stoneNum.ToString();
        ironAmount.text = ironNum.ToString();
        goldAmount.text = goldNum.ToString();
    }
}
