using Features.GamePlay.Puzzle.Assemble.Runtime;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Features.GamePlay.Puzzle.Assemble.Editor
{
    [DisallowMultipleComponent]
    public class PuzzlePartScanner : MonoBehaviour
    {
        [SerializeField] private Vector2Int _gridSize = new(10, 6);
        [SerializeField] private float _distance = 0.5f;
        
        [Button]
        private void Scan()
        {
            var childCount = transform.childCount;

            for (var i = 0; i < childCount; i++)
            {
                var target = transform.GetChild(i).GetComponentInChildren<PuzzlePart>();

                target.SetId(i);

                Undo.RecordObject(target, "Id set");
                EditorUtility.SetDirty(target);
            }
        }
        
        [Button]
        private void Separate()
        {
            var counter = 0;

            var start = new Vector2(-_gridSize.x / 2f + 0.5f, _gridSize.y / 2f - 0.5f);

            for (var y = 0; y < _gridSize.y; y++)
            {
                for (var x = 0; x < _gridSize.x; x++)
                {
                    var part = transform.GetChild(counter);

                    part.position = new Vector2(x + x * _distance, -(y + y * _distance)) + start;
                    
                    counter++;
                }
            }
        }
        
        [Button]
        private void Collapse()
        {
            var counter = 0;
            
            var start = new Vector2(-_gridSize.x / 2f + 0.5f, _gridSize.y / 2f - 0.5f);

            for (var y = 0; y < _gridSize.y; y++)
            {
                for (var x = 0; x < _gridSize.x; x++)
                {
                    var part = transform.GetChild(counter);

                    part.position = new Vector2(x, -y) + start;
                    
                    counter++;
                }
            }
        }
        
        [Button]
        private void ProcessSprites()
        {
            var childCount = transform.childCount;

            for (var i = 0; i < childCount; i++)
            {
                var target = transform.GetChild(i).GetComponentInChildren<PuzzlePart>();
                var sprite = target.GetComponent<SpriteRenderer>();
                var mask = target.GetComponent<SpriteMask>();

                mask.sprite = sprite.sprite;
                sprite.sortingOrder = i + 1;
                mask.frontSortingOrder = i + 1;
                
                target.SetId(i);

                Undo.RecordObject(target, "Id set");
                EditorUtility.SetDirty(target);
            }
        }
    }
}