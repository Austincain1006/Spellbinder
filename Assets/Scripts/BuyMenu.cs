using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    public Dictionary<string, int> primalInventory;
    [SerializeField] Sprite[] primalSprites;
    [SerializeField] TextMeshProUGUI airMenuAmount;
    [SerializeField] TextMeshProUGUI chaosMenuAmount;
    [SerializeField] TextMeshProUGUI earthMenuAmount;
    [SerializeField] TextMeshProUGUI fireMenuAmount;
    [SerializeField] TextMeshProUGUI orderMenuAmount;
    [SerializeField] TextMeshProUGUI waterMenuAmount;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] TileManager tileManager;
    [SerializeField] UserInterface ui;
    [SerializeField] Button componentA;
    [SerializeField] Button componentB;
    [SerializeField] Button mixingButton;
    
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
        if (tileManager.BuyMagic("Magic Air_0", 1))
        {
            primalInventory["Magic Air_0"] += 1;
            airMenuAmount.text = primalInventory["Magic Air_0"].ToString();
        }
        else
        {
            Debug.Log("Not enough money!");
        }

    }

    public void BuyChaosMagic()
    {
        if (tileManager.BuyMagic("MagicChaos_0", 1))
        {
            primalInventory["MagicChaos_0"] += 1;
            chaosMenuAmount.text = primalInventory["MagicChaos_0"].ToString();
        }
        else
        {
            Debug.Log("Not enough money!");
        }
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

    public void setCoinCounter(string s)
    {
        coinCounter.text = s;
    }

    public void SetComponentA()
    {
        print("Clicked A");
        if (ui.mouseFollower.prevSprite.name != "empty_0")
        {

            componentA.image.sprite = ui.mouseFollower.prevSprite;
        }

    }

    public void SetComponentB()
    {
        print("Clicked B");
        if (ui.mouseFollower.prevSprite.name != "empty_0")
        {

            componentB.image.sprite = ui.mouseFollower.prevSprite;
        }
    }

    public void MixComponents()
    {
        print("Clicked Mix");
        if (ui.mouseFollower.prevSprite.name != "empty_0")
        {

            mixingButton.image.sprite = ui.mouseFollower.prevSprite;

            if (componentA.image.sprite.name != "empty_0" && componentB.image.sprite.name != "empty_0"
            && componentB.image.sprite.name != componentA.image.sprite.name)
            {
                char a = getMagicAbbreviation(componentA.image.sprite.name);
                char b = getMagicAbbreviation(componentB.image.sprite.name);
                string s = mixComponents(a, b);
                string filepath = "Art/" + s + ".png";
                Debug.Log($"Loading {filepath}");
                //mixingButton.image.sprite = Resources.Load<Sprite>(filepath);
                mixingButton.image.sprite = Resources.Load<Sprite>("MagicExplosion_0.png");

            }

        }
    }

    char getMagicAbbreviation(string s)
    {
        switch (s)
        {
            case "Magic Air_0":
                return 'A';
            case "MagicChaos_0":
                return 'C';
            case "MagicEarth_0":
                return 'E';
            case "MagicFire_0":
                return 'F';
            case "MagicOrder_0":
                return 'O';
            case "MagicWater_0":
                return 'W';
            default:
                return 'X';
        }
    }

    string mixComponents(char a, char b)
    {
        switch (a)
        {
            case 'A':
                switch (b)
                {
                    case 'C':
                        return "MagicTornado_0";
                    case 'E':
                        return "MagicErosion_0";
                    case 'F':
                        return "MagicStorm_0";
                    case 'O':
                        return "MagicMovement_0";
                    case 'W':
                        return "MagicRain_0";
                }
                break;
            case 'C':
                switch (b)
                {
                    case 'A':
                        return "MagicTornado_0";
                    case 'E':
                        return "MagicSand_0";
                    case 'F':
                        return "MagicExplosion_0";
                    case 'O':
                        return "MagicBalance_0";
                    case 'W':
                        return "MagicSpace_0";
                }
                break;
            case 'E':
                switch (b)
                {
                    case 'A':
                        return "MagicErosion_0";
                    case 'C':
                        return "MagicSand_0";
                    case 'F':
                        return "MagicMagma_0";
                    case 'O':
                        return "MagicCrystal_0";
                    case 'W':
                        return "MagicLife_0";
                }
                break;
            case 'F':
                switch (b)
                {
                    case 'A':
                        return "MagicStorm_0";
                    case 'C':
                        return "MagicExplosion_0";
                    case 'E':
                        return "MagicMagma_0";
                    case 'O':
                        return "MagicEnergy_0";
                    case 'W':
                        return "MagicSteam_0";
                }
                break;
            case 'O':
                switch (b)
                {
                    case 'A':
                        return "MagicMovement_0";
                    case 'C':
                        return "MagicBalance_0";
                    case 'E':
                        return "MagicCrystal_0";
                    case 'F':
                        return "MagicEnergy_0";
                    case 'W':
                        return "MagicIce_0";
                }
                break;
            case 'W':
                switch (b)
                {
                    case 'A':
                        return "MagicRain_0";
                    case 'C':
                        return "MagicSpace_0";
                    case 'E':
                        return "MagicLife_0";
                    case 'F':
                        return "MagicSteam_0";
                    case 'O':
                        return "MagicIce_0";
                }
                break;
        }
        Debug.LogError("NO COMBINATION FOUND!");
        return "empty_0";
    }//end func

    public void setComponentAir()
    {
        componentA.image.sprite = primalSprites[0];
    }

    public void setComponentChaos()
    {
        componentA.image.sprite = primalSprites[1];
    }

    public void setComponentEarth()
    {
        componentA.image.sprite = primalSprites[2];
    }

    public void setComponentFire()
    {
        componentB.image.sprite = primalSprites[3];
    }

    public void setComponentOrder()
    {
        componentB.image.sprite = primalSprites[4];
    }
    
    public void setComponentWater()
    {
        componentB.image.sprite = primalSprites[5];
    }
}
