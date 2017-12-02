using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static Vector2 RandomVectorInBox(Vector2 pos1, Vector2 pos2)
    {
        return new Vector2(Random.Range(pos1.x, pos2.x), Random.Range(pos1.y, pos2.y));
    }



    public static bool IsVectorInBox(Vector2 posToCheck, Vector2 boxMinPos, Vector2 boxMaxPos)
    {
        return (posToCheck.x >= boxMinPos.x && posToCheck.y >= boxMinPos.y) && (posToCheck.x <= boxMaxPos.x && posToCheck.y <= boxMaxPos.y);
    }
}
