using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.DependencyServices
{
    public interface IPicturePicker
    {
        Task<byte[]> GetPictureFromCamera();
        Task<byte[]> GetPictureFromGallery();
    }
}
