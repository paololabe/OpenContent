﻿using Satrabel.OpenContent.Components.Manifest;


namespace Satrabel.OpenContent.Components
{
    public static class AdditionalDataUtils
    {

        internal static string GetScope(string scopeType, int portalId, int tabId, int moduleId, int tabModuleId)
        {
            if (scopeType == "portal")
            {
                return scopeType + "/" + portalId;
            }
            else if (scopeType == "tab")
            {
                return scopeType + "/" + tabId;
            }
            else if (scopeType == "tabmodule")
            {
                return scopeType + "/" + tabModuleId;
            }
            else if (scopeType == "module")
            {
                return scopeType + "/" + moduleId;
            }
            else
            {
                return "module/" + moduleId;
            }
        }

        internal static string GetScope(AdditionalDataManifest manifest, int portalId, int tabId, int moduleId, int tabModuleId)
        {
            return AdditionalDataUtils.GetScope(manifest.ScopeType, portalId, tabId, moduleId, tabModuleId);
        }
    }
}