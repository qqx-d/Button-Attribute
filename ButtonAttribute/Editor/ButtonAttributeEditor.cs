using UnityEngine;
using UnityEditor;
using System.Reflection;

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class ButtonAttributeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MonoBehaviour mono = (MonoBehaviour)target;
        MethodInfo[] methods = mono.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (MethodInfo method in methods)
        {
            ButtonAttribute buttonAttribute = (ButtonAttribute)method.GetCustomAttribute(typeof(ButtonAttribute));
            if (buttonAttribute != null)
            {
                string buttonLabel = string.IsNullOrEmpty(buttonAttribute.ButtonLabel) ? method.Name : buttonAttribute.ButtonLabel;
                if (GUILayout.Button(buttonLabel))
                {
                    method.Invoke(mono, null);
                }
            }
        }
    }
}
#endif