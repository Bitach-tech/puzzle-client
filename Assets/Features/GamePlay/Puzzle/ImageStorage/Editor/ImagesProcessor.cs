using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GamePlay.Common.Paths;
using GamePlay.Puzzle.ImageStorage.Runtime;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Features.GamePlay.Puzzle.ImageStorage.Editor
{
    [CreateAssetMenu(fileName = "ImageProcessor",
        menuName = GamePlayAssetsPaths.ImageStorage + "Processor")]
    public class ImagesProcessor : ScriptableObject
    {
        [SerializeField] private Vector2Int _gridSize = new(10, 6);
        [SerializeField] private float _cellSize;
        [SerializeField] private float _padding;
        
        [SerializeField] private Vector2 _offset;
        [SerializeField] private Vector2 _previewSize;
        
        [SerializeField] private Vector2 _backgroundPosition;
        [SerializeField] private Vector2 _backgroundSize;
        
        [SerializeField] private Texture2D[] _images;

        [SerializeField] private PuzzleImage[] _assets;

        [Button]
        private void Process()
        {
            for (var i = 0; i < _images.Length; i++)
                OnPostprocessTexture(_images[i], _assets[i]);
        }
        
        private void OnPostprocessTexture(Texture2D texture, PuzzleImage asset)
        {
            var assetPath = AssetDatabase.GetAssetPath(texture);
            var textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            
            var fileName = Path.GetFileNameWithoutExtension(assetPath);

            var rects = new List<Rect>();

            var position = new Vector2(_offset.x, texture.height - _offset.y - _cellSize);
            var step = _padding;

            for (var y = 0; y < _gridSize.y; y++)
            {
                for (var x = 0; x < _gridSize.x; x++)
                {
                    var rectPosition = position;
                    rectPosition.x += x * step;
                    rectPosition.y -= y * step;

                    var rect = new Rect()
                    {
                        position = rectPosition,
                        size = new Vector2(_cellSize, _cellSize)
                    };

                    rects.Add(rect);
                }
            }
            
            var preview = new Rect
            {
                position = new Vector2(
                    texture.width / 2f - _previewSize.x / 2f,
                    texture.height / 2f - _previewSize.y / 2f),
                size = _previewSize
            };

            var background = new Rect
            {
                position = _backgroundPosition,
                size = _backgroundSize
            };

            
            rects.Add(background);
            rects.Add(preview);

            var result = rects.ToArray();

            var rectNum = 0;

            textureImporter.spritesheet = result.Select(rect => new SpriteMetaData
            {
                pivot = Vector2.down, 
                alignment = (int) SpriteAlignment.Center,
                rect = rect, 
                name = fileName + "_" + rectNum++
            }).ToArray();
        
            AssetDatabase.ForceReserializeAssets(new List<string> { assetPath });
            AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

            var sprites = AssetDatabase.LoadAllAssetsAtPath(assetPath).OfType<Sprite>().ToArray();
            
            asset.SetPreview(sprites[^1]);
            asset.SetBackground(sprites[^2]);
            
            Array.Resize(ref sprites, sprites.Length - 2);
            asset.SetImages(sprites);
        }
    }
}