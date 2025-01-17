﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentTypeToViewEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = (AttachmentType) value;
            var par = parameter.ToString();

            if ((type == AttachmentType.Picture || type == AttachmentType.GalleryPicture) && par == "Picture")
                return true;
            if (type == AttachmentType.Text && par == "Text")
                return true;
            if ((type == AttachmentType.Video || type == AttachmentType.GalleryVideo) && par == "Video")
                return true;
            if (type == AttachmentType.Audio && par == "Audio")
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
