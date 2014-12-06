using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (Motor))]
public class MotorInspector : Editor {
	public override void OnInspectorGUI(){
		Motor mTarget = (Motor) target;
		DrawDefaultInspector();
		mTarget.speed = EditorGUILayout.FloatField("Speed", mTarget.speed);
	}
	
}
