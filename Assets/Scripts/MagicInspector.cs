using UnityEngine;
using UnityEngine.UI;

public class MagicInspector : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image Product;
    [SerializeField] private UnityEngine.UI.Image ComponentA;
    [SerializeField] private UnityEngine.UI.Image ComponentB;
    [SerializeField] public Sprite[] primalMagics;


    public void Test()
    {
        Debug.Log($"Magic Inspector successfully listened to event.");
    }

    public void SetProduct(Sprite s)
    {
        Product.sprite = s;
        string guh = decomposeMagic(s.name);

        ComponentA.sprite = getSpriteOfPrimal(guh[0]);
        ComponentB.sprite = getSpriteOfPrimal(guh[1]);
    }

    // Return the Two primal magics that make up an element
    string decomposeMagic(string s)
    {
        // Order = O
        // Chaos = C
        // Fire = F
        // Water = W
        // Earth = E
        // Air = A
        switch (s)
        {
            case "empty_0":
                return null;
            case "MagicBalance_0":
                return "OC";
            case "MagicCrystal_0":
                return "OE";
            case "MagicEnergy_0":
                return "OF";
            case "MagicExplosion_0":
                return "CF";
            case "MagicIce_0":
                return "OW";
            case "MagicLife_0":
                return "EW";
            case "MagicMagma_0":
                return "EF";
            case "MagicMovement_0":
                return "OA";
            case "MagicSand_0":
                return "EC";
            case "MagicSpace_0":
                return "WC";
            case "MagicSteam_0":
                return "WF";
            case "MagicStorm_0":
                return "AF";
            case "MagicTornado_0":
                return "AC";
            case "MagicErosion_0":
                return "EA";
            case "MagicRain_0":
                return "AW";
            case "Magic Air_0":
                return "AA";
            case "MagicChaos_0":
                return "CC";
            case "MagicEarth_0":
                return "EE";
            case "MagicFire_0":
                return "FF";
            case "MagicOrder_0":
                return "OO";
            case "MagicWater_0":
                return "WW";
            default:
                Debug.LogError($"DECOMPOSE MAGIC FOR {s} IS NONEXISTANT");
                return null;
        }//end switch

    }// decomposeMagic

    Sprite getSpriteOfPrimal(char primalName)
    {
        switch (primalName)
        {
            case 'A':
                return primalMagics[0];
            case 'C':
                return primalMagics[1];
            case 'E':
                return primalMagics[2];
            case 'F':
                return primalMagics[3];
            case 'O':
                return primalMagics[4];
            case 'W':
                return primalMagics[5];
            default:
                return null;
            
        }
    }
    
}
