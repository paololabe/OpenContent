﻿using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;


namespace Satrabel.OpenContent.Components.TemplateHelpers
{
    public class ImageUri : PortalFileUri
    {
        #region Constructors

        public ImageUri(int fileId)
            : base(fileId)
        {
        }
        public ImageUri(string fileFullPath)
            : base(PortalSettings.Current.PortalId, fileFullPath)
        {
        }
        public ImageUri(string path, string filename)
            : base(PortalSettings.Current.PortalId, path, filename)
        {
        }
        public ImageUri(int portalid, string fileFullPath)
            : base(portalid, fileFullPath)
        {
        }
        public ImageUri(int portalid, string path, string filename)
            : base(portalid, path, filename)
        {
        }
        #endregion

        public string GetImageUrl(int width, int height)
        {
            var ratio = new Ratio(width, height);
            return ImageHelper.GetImageUrl(FileInfo, ratio);
        }

        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <param name="columnWidth">Size of the image. In Bootstrap 12th</param>
        /// <param name="ratioString">The ratio string.</param>
        /// <param name="isMobile">if set to <c>true</c> [is mobile].</param>
        /// <returns></returns>
        public string GetImageUrl(float columnWidth, string ratioString, bool isMobile)
        {
            if (columnWidth < 0) columnWidth = 12;

            if (string.IsNullOrEmpty(ratioString)) ratioString = "1x1";
            var ratio = new Ratio(ratioString);

            int maxWidth;
            if (columnWidth > 12)
                maxWidth = (int)Math.Round(columnWidth);
            else
                maxWidth = ImageHelper.CalculateMaxPixels(columnWidth, isMobile);
            ratio.SetWidth(maxWidth);
            return ImageHelper.GetImageUrl(FileInfo, ratio);
        }

        public string GetImageUrl(string ratioString, float columnHeight, bool isMobile)
        {
            if (columnHeight < 0 || columnHeight > 12) columnHeight = 12;
            if (string.IsNullOrEmpty(ratioString)) ratioString = "1x1";
            var ratio = new Ratio(ratioString);
            var maxHeight = ImageHelper.CalculateMaxPixels(columnHeight, isMobile);
            ratio.SetHeight(maxHeight);
            return ImageHelper.GetImageUrl(FileInfo, ratio);
        }

        /// <summary>
        /// Gets an optimial image for facebook.
        /// Based on the Facebook best practices https://developers.facebook.com/docs/sharing/best-practices#images
        /// Prefereably 1200 x 630 or larger, minimal 600 x 315 and not smaller then 200 x 200
        /// </summary>
        /// <returns></returns>
        public string GetFacebookImageUrl()
        {
            return ImageHelper.GetFacebookImageUrl(FileInfo);
        }


        [Obsolete("This method is obsolete since dec 2015; use public string EditUrl(ModuleInfo module) instead")]
        public string EditImageUrl(ModuleInfo module)
        {
            return EditUrl(module);
        }

        [Obsolete("This method is obsolete since dec 2015; use public string EditUrl() instead")]
        public string EditImageUrl()
        {
            return EditUrl();
        }

    }
}