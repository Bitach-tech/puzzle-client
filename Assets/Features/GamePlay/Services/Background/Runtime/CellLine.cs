using Common.Structs;
using UnityEngine;

namespace GamePlay.Services.Background.Runtime
{
    public class CellLine
    {
        public CellLine(
            RectTransform start,
            RectTransform target,
            LineView line,
            GameBackgroundConfigAsset config)
        {
            _start = start;
            _target = target;
            _line = line;
            _config = config;
        }

        private const float _epsilon = 0.01f;
        private readonly GameBackgroundConfigAsset _config;
        private readonly LineView _line;

        private readonly RectTransform _start;
        private readonly RectTransform _target;

        public void Update(float delta)
        {
            var self = _line.Position;
            var target = _target.anchoredPosition;
            var speed = _config.Speed * delta;

            var direction = (target - _start.anchoredPosition).normalized;

            var result = Vector2.MoveTowards(self, target, speed);

            _line.SetPosition(result);
            var distance = Vector2.Distance(result, _target.anchoredPosition);

            if (distance < _epsilon)
                _line.SetPosition(_start.anchoredPosition);

            var angle = direction.ToAngle();
            _line.Rotate(angle);
        }
    }
}