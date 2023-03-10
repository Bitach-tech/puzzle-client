using GamePlay.Level.Assemble.Runtime;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Level.Assemble.Editor
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
                var position = target.transform.position;
                
                position.z = -(i + 1);
                target.transform.position = position;
                
                target.SetId(i);

                Undo.RecordObject(target, "Id set");
                EditorUtility.SetDirty(target);
            }
        }
        
        [Button]
        private void SwitchSprites()
        {
            var childCount = transform.childCount;

            for (var i = 0; i < childCount; i++)
            {
                var source = transform.GetChild(i).GetChild(0);
                var target = transform.GetChild(i).GetChild(1);
                
                var sourceSprite = source.GetComponent<SpriteRenderer>();
                var sourceMask = source.GetComponent<SpriteMask>();
                
                var targetSprite = target.GetComponent<SpriteRenderer>();
                var targetMask = target.GetComponent<SpriteMask>();
                
                targetSprite.sprite = sourceSprite.sprite;
                targetMask.sprite = sourceMask.sprite;
                targetMask.sortingOrder = sourceMask.sortingOrder;
                targetMask.frontSortingOrder = sourceMask.frontSortingOrder;
                
                Undo.RecordObject(target, "Switched");
                EditorUtility.SetDirty(target);
            }
        }
    }
}