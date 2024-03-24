using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTestApp
{
    interface IManageFiles
    {
        void ReplaceInDesignFile(string filePath, bool toDot = true);
        string OpenFile(string path);
        void SaveFile(string path, string content);
        string ReplaceToAll(string content, string input, string output);
    }
}
