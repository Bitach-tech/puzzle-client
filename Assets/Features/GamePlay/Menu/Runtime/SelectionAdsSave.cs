using System;
using System.Linq;

namespace GamePlay.Menu.Runtime
{
    [Serializable]
    public class SelectionAdsSave
    {
        private int[] _rewarded;

        public bool IsRewarded(int index)
        {
            if (_rewarded == null)
                return false;

            if (_rewarded.Contains(index) == false)
                return false;

            return true;
        }

        public void OnRewarded(int index)
        {
            if (_rewarded == null)
            {
                _rewarded = new int[1];
                _rewarded[0] = index;
                return;
            }

            Array.Resize(ref _rewarded, _rewarded.Length + 1);

            _rewarded[^1] = index;
        }
    }
}