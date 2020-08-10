using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player_Overview))]
public class PlayerGUI : Editor
{
    public override void OnInspectorGUI()
    {
        Player_Overview myTarget = (Player_Overview)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Draw Card"))
		{
            myTarget.DrawCard();
        }
    }
}
