using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaterThan
{
    public class SelectableFileInfo
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }    
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long Size { get; set; }

        public static List<SelectableFileInfo> GetFiles(string path, DateTime modifiedDate)
        {
            var fileInfoList = new List<SelectableFileInfo>();

            try
            {
                foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
                {
                    FileInfo info = new FileInfo(file);

                    if (info.LastWriteTime >= modifiedDate)
                    {
                        fileInfoList.Add(new SelectableFileInfo
                        {
                            IsSelected = false,
                            Name = info.Name,
                            Path = info.FullName,
                            CreatedDate = info.CreationTime,
                            ModifiedDate = info.LastWriteTime,
                            Size = info.Length
                        });
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have the required permission.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified path is invalid.");
            }

            return fileInfoList;
        }

    }
}
