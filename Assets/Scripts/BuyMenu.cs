using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    public Dictionary<string, int> primalInventory;
    [SerializeField] TextMeshProUGUI airMenuAmount;
    [SerializeField] TextMeshProUGUI chaosMenuAmount;
    [SerializeField] TextMeshProUGUI earthMenuAmount;
    [SerializeField] TextMeshProUGUI fireMenuAmount;
    [SerializeField] TextMeshProUGUI orderMenuAmount;
    [SerializeField] TextMeshProUGUI waterMenuAmount;
    void Start()
    {
        primalInventory = new Dictionary<string, int>();
        primalInventory.Add("Magic Air_0", 3);
        primalInventory.Add("MagicChaos_0", 3);
        primalInventory.Add("MagicEarth_0", 3);
        primalInventory.Add("MagicFire_0", 3);
        primalInventory.Add("MagicOrder_0", 3);
        primalInventory.Add("MagicWater_0", 3);


    }

    public void BuyAirMagic()
    {
        primalInventory["Magic Air_0"] += 1;
        airMenuAmount.text = primalInventory["Magic Air_0"].ToString();
    }

    public void BuyChaosMagic()
    {
        primalInventory["MagicChaos_0"] += 1;
        chaosMenuAmount.text = primalInventory["MagicChaos_0"].ToString();
    }

    public void BuyEarthMagic()
    {
        primalInventory["MagicEarth_0"] += 1;
        earthMenuAmount.text = primalInventory["MagicEarth_0"].ToString();
    }

    public void BuyFireMagic()
    {
        primalInventory["MagicFire_0"] += 1;
        fireMenuAmount.text = primalInventory["MagicFire_0"].ToString();
    }

    public void BuyOrderMagic()
    {
        primalInventory["MagicOrder_0"] += 1;
        orderMenuAmount.text = primalInventory["MagicOrder_0"].ToString();
    }

    public void BuyWaterMagic()
    {
        primalInventory["MagicWater_0"] += 1;
        waterMenuAmount.text = primalInventory["MagicWater_0"].ToString();
    }
}
