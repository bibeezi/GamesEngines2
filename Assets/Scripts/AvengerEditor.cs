using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AvengerShipFight))]
public class AvengerEditor : Editor
{
    void OnSceneGUI(){
        AvengerShipFight fow = (AvengerShipFight) target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 45, 500);

        Vector3 viewAngleA = fow.DirFromAngle (-45, false);
        Vector3 viewAngleB = fow.DirFromAngle (45, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * 500);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * 500);

        Handles.color = Color.red;
        if(fow.seekLeviathan.transform.position != null){
            Handles.DrawLine(fow.transform.position, fow.seekLeviathan.transform.position);
        }
    }
}