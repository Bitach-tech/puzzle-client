using GamePlay.Level.Assemble.Runtime;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Level.Assemble.Editor
{
    [DisallowMultipleComponent]
    public class PuzzleTargetsScanner : MonoBehaviour
    {
        [Button]
        private void Scan()
        {
            var childCount = transform.childCount;

            for (var i = 0; i < childCount; i++)
            {
                var target = transform.GetChild(i).GetComponent<PuzzleTarget>();

                target.SetId(i);

                Undo.RecordObject(target, "Id set");
                EditorUtility.SetDirty(target);
            }
        }
    }
}