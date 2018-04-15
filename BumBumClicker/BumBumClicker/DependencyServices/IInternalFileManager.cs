using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.DependencyServices
{
      public interface IInternalFileManager
        {
            bool FileExists(string fileName);
                 
            bool DirectoryExists(string directoryName);
            
            Task<byte[]> GetBytes(string fileName);
            
            Task WriteBytes(string fileName, byte[] data);

            Task Delete(string fileName);
        }
    
}
