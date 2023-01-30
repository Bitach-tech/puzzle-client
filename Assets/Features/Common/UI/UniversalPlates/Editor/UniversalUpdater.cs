using Common.UI.UniversalPlates.Runtime.Abstract;
using UnityEditor;
using UnityEngine;

namespace Common.UI.UniversalPlates.Editor
{
    [InitializeOnLoad]
    public class UniversalUpdater
    {
        static UniversalUpdater()
        {
            EditorApplication.update += Update;
        }

        private static void Update()
        {
            if (Application.isPlaying == true)
                return;

            var properties = Object.FindObjectsOfType<UniversalProperty>();

            foreach (var property in properties)
            {
                property.UpdateProperty();
                EditorUtility.SetDirty(property.gameObject);
                Undo.RecordObject(property.gameObject, "Property updated");
            }
        }
    }
}