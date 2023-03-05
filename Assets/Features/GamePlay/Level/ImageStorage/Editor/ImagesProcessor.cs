using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GamePlay.Level.ImageStorage.Runtime;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Level.ImageStorage.Editor
{
   // [CreateAssetMenu(fileName = "ImageProcessor",
  //      menuName = GamePlayAssetsPaths.ImageStorage + "Processor")]
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

            if (textureImporter == null)
                throw new NullReferenceException();
            
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
            
            rects.Add(preview);
            rects.Add(background);

            var rectNum = 0;

            var spriteSheet = new SpriteMetaData[rects.Count];

            for (var i = 0; i < spriteSheet.Length; i++)
            {
                var data = new SpriteMetaData
                {
                    pivot = Vector2.down,
                    alignment = (int)SpriteAlignment.Center,
                    rect = rects[i],
                    name = fileName + "_" + rectNum++
                };

                spriteSheet[i] = data;
            }

            textureImporter.spritesheet = spriteSheet;
        
            AssetDatabase.ForceReserializeAssets(new List<string> { assetPath });
            AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

            int GetOrder(Sprite sprite)
            {
                var target = sprite.name.Replace($"{fileName}_", "");
                Debug.Log($"{fileName} {sprite.name} {target}");
                var order = int.Parse(target);
                
                return order;
            }
            
            var sprites = AssetDatabase.LoadAllAssetsAtPath(assetPath)
                .OfType<Sprite>()
                .OrderBy(GetOrder)
                .ToArray();

            var backgroundIndex = sprites.Length - 1;
            var previewIndex = sprites.Length - 2;
            
            Debug.Log($"Indexes: {previewIndex} {backgroundIndex}");
            Debug.Log($"Names: {sprites[previewIndex].name} {sprites[backgroundIndex].name}");

            for (var i = 0; i < sprites.Length; i++)
                Debug.Log($"[{i}]: {sprites[i].name}");
            
            asset.SetPreview(sprites[previewIndex]);
            asset.SetBackground(sprites[backgroundIndex]);
            
            Array.Resize(ref sprites, sprites.Length - 2);
            asset.SetImages(sprites);
        }
    }
}