using System.IO;
using System.Linq;
using Common.NestedScriptableObjects.Attributes;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Common.NestedScriptableObjects.Editor
{
    [DrawerPriority(DrawerPriorityLevel.SuperPriority)]
    public class NestedScriptableObjectFieldAttributeDrawer<T> :
        OdinAttributeDrawer<NestedScriptableObjectFieldAttribute, T>
        where T : ScriptableObject
    {
        private string[] assetPaths = new string[0];
        private Object Parent => (Object)Property.Tree.RootProperty.ValueEntry.WeakSmartValue;

        protected override void Initialize()
        {
            Attribute.Type = typeof(T);
            base.Initialize();
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            if (assetPaths.Count() == 0)
                assetPaths = GetAllScriptsOfType();
            if (ValueEntry.SmartValue == null && !Application.isPlaying)
            {
                //Display value dropdown
                EditorGUI.BeginChangeCheck();
                var rect = EditorGUILayout.GetControlRect();
                rect = EditorGUI.PrefixLabel(rect, label);
                var valueIndex = SirenixEditorFields.Dropdown(rect, 0, GetDropdownList(assetPaths));
                if (EditorGUI.EndChangeCheck() && valueIndex > 0)
                {
                    var newObject = (T)ScriptableObject.CreateInstance(AssetDatabase
                        .LoadAssetAtPath<MonoScript>(assetPaths[valueIndex - 1]).GetClass());
                    CreateAsset(newObject);
                    ValueEntry.SmartValue = newObject;
                }
            }
            else
            {
                //Display object field with a delete button
                EditorGUILayout.BeginHorizontal();
                CallNextDrawer(label);
                var rect = EditorGUILayout.GetControlRect(GUILayout.Width(20));
                EditorGUI.BeginChangeCheck();
                SirenixEditorGUI.IconButton(rect, EditorIcons.X);
                EditorGUILayout.EndHorizontal();
                if (EditorGUI.EndChangeCheck())
                {
                    //If delete button was pressed:
                    AssetDatabase.Refresh();
                    GameObject.DestroyImmediate(ValueEntry.SmartValue, true);
                    AssetDatabase.ForceReserializeAssets(new[] { AssetDatabase.GetAssetPath(Parent) });
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
        }

        protected virtual string[] GetAllScriptsOfType()
        {
            var items = AssetDatabase.FindAssets("t:Monoscript", new[] { "Assets/Features" })
                .Select(x => AssetDatabase.GUIDToAssetPath(x))
                .Where(x => IsCorrectType(AssetDatabase.LoadAssetAtPath<MonoScript>(x)))
                .ToArray();
            return items;
        }

        protected bool IsCorrectType(MonoScript script)
        {
            if (script != null)
            {
                var scriptType = script.GetClass();
                if (scriptType != null &&
                    (scriptType.Equals(Attribute.Type) || scriptType.IsSubclassOf(Attribute.Type)) &&
                    !scriptType.IsAbstract) return true;
            }

            return false;
        }

        protected string[] GetDropdownList(string[] paths)
        {
            var names = paths.Select(s => Path.GetFileName(s)).ToList();
            names.Insert(0, "null");
            return names.ToArray();
        }

        protected void CreateAsset(T newObject)
        {
            newObject.name = "_" + newObject.GetType().Name;
            AssetDatabase.Refresh();
            AssetDatabase.AddObjectToAsset(newObject, Parent);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        protected virtual void RemoveAsset(ScriptableObject objectToRemove)
        {
            Object.DestroyImmediate(objectToRemove, true);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}