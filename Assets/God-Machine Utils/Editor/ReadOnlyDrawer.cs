using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer (typeof (ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer {
    public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {
        string valueStr;

        switch (prop.propertyType) {
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            case SerializedPropertyType.Boolean:
                valueStr = prop.boolValue.ToString ();
                break;
            case SerializedPropertyType.Integer:
                valueStr = prop.intValue.ToString ();
                break;
            case SerializedPropertyType.Float:
                valueStr = prop.floatValue.ToString ("0.00000");
                break;
            case SerializedPropertyType.Vector2:
                valueStr = prop.vector2Value.ToString ();
                break;
            case SerializedPropertyType.Vector3:
                valueStr = prop.vector3Value.ToString ();
                break;
            default:
                valueStr = "Not Supported";
                break;
        }

        EditorGUI.LabelField (position, label.text, valueStr);
    }
}