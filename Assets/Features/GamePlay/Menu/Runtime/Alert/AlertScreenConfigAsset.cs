using GamePlay.Menu.Common;
using UnityEngine;

namespace GamePlay.Menu.Runtime.Alert
{
    [CreateAssetMenu(fileName = MenuRoutes.AlertName,
        menuName = MenuRoutes.AlertPath)]
    public class AlertScreenConfigAsset : ScriptableObject
    {
        [SerializeField] private string _ownerName;

        public string OwnerName => _ownerName;
    }
}