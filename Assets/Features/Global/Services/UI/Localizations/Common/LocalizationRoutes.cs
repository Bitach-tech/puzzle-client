using Global.Common;

namespace Global.UI.Localizations.Common
{
    public static class LocalizationRoutes
    {
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Localization";
        public const string ServicePath = GlobalAssetsPaths.Root + "UI/Localization/Service";

        public const string StorageName = GlobalAssetsPrefixes.Config + "Localization";
        public const string StoragePath = GlobalAssetsPaths.Root + "UI/Localization/Storage";

        public const string DataName = "Localization_Data";
        public const string DataPath = GlobalAssetsPaths.Root + "UI/Localization/Data";
    }
}