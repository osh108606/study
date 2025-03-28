using UnityEngine;

public class ChameleonWeapon : Weapon
{
    int BodyStack = 0;
    int HeadStack = 0;
    int LegStack = 0;
    public override void Hittied(BodyPart bodyPart)
    {
        if (bodyPart == BodyPart.Body)
        {
            BodyStack++;
            Debug.Log(BodyStack);
        }
        else if (bodyPart == BodyPart.Head)
        {
            HeadStack++;
            Debug.Log(HeadStack);
        }
        else if (bodyPart == BodyPart.Leg)
        {
            LegStack++;
            Debug.Log(LegStack);
        }
    }
    
}
