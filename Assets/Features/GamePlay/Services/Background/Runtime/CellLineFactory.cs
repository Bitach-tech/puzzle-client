using UnityEngine;

namespace GamePlay.Services.Background.Runtime
{
    public class CellLineFactory
    {
        public CellLineFactory(
            LineView linePrefab,
            RectTransform root,
            GameBackgroundConfigAsset config)
        {
            _linePrefab = linePrefab;
            _root = root;
            _config = config;
        }

        private readonly GameBackgroundConfigAsset _config;

        private readonly LineView _linePrefab;
        private readonly RectTransform _root;

        public CellLine[] Create(RectTransform start, RectTransform target)
        {
            var distance = Vector2.Distance(start.anchoredPosition, target.anchoredPosition);
            var amount = Mathf.CeilToInt(distance / (_config.LineWidth + _config.DistanceBetweenLines));

            var lines = new CellLine[amount];
            var direction = (target.anchoredPosition - start.anchoredPosition).normalized;

            for (var i = 0; i < amount; i++)
            {
                var position = start.anchoredPosition +
                               direction * (_config.DistanceBetweenLines + _config.LineWidth) * i;

                var lineObject = Object.Instantiate(_linePrefab, _root);
                lineObject.SetPosition(position);
                var line = new CellLine(start, target, lineObject, _config);

                lines[i] = line;

                if (i % 2 == 0)
                    lineObject.DisableOneCell();
            }

            return lines;
        }
    }
}