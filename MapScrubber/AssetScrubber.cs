using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapScrubber
{
    public class AssetScrubber
    {
        public string AssetDirectory;
        public string OutputDirectory;
        public List<string> FileList;

        public AssetScrubber()
        {
            FileList = new List<string>();
        }

        public string OpenWorkSet()
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "TXT Files (*.txt*)|*.txt*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                string s = File.ReadAllText(sFileName);
                ConvertWorkSetToAssetList(s);
                return s;
            }
            else
            {
                return "";
            }
        }

        public void ConvertWorkSetToAssetList(string s)
        {
            int start = s.IndexOf("map_asset_references");
            s = s.Substring(start);
            start = s.IndexOf("[") + 1;
            int end = s.IndexOf("]") - start;
            s = s.Substring(start, end);
            s = s.Replace("\"", "");
            s = s.Replace("/", "\\");
            s = s.Replace("\t", "");
            s = s.Replace(",\r", "");
            FileList = s.Split('\n').ToList();
            AddMatTexToList(FileList);
        }

        public void AddMatTexToList(List<string> list)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Asset Directory";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                AssetDirectory = fbd.SelectedPath;
            }

            for(int i = 0; i < list.Count; i++)
            {
                string path = list[i];
                if (path.Contains(".vmat"))
                {
                    Console.WriteLine(path);
                    GetMaterial(Path.Combine(AssetDirectory,path));
                    
                }
                else
                {
                    Console.WriteLine(list[i]);
                }
            }
        }

        public void GetMaterial(string s)
        {

            DirectoryInfo dir = new DirectoryInfo(AssetDirectory);


            s = s.Replace(".vmat", ".vmat_c");

            if (!File.Exists(s))
            {
                return;
            }
            
            try
            {
                string contents = File.ReadAllText(s);
                int index = contents.IndexOf(".vtex") + 5;

                while (index != -1)
                {
                    index = contents.IndexOf(".vtex") + 5;
                    int lastIndex = contents.LastIndexOf(@"/",index);
                    
                    if (lastIndex == -1)
                    {

                        index = -1;
                        continue;
                    }
                    string textureFile = contents.Substring(lastIndex, index - lastIndex);
                    if (!textureFile.Contains(".vmat"))
                    {
                        //Console.WriteLine("\t\tExtracting Textures From Material: ");
                        textureFile = textureFile.Replace(@"/", "");
                        FileInfo[] files = dir.GetFiles("*" + textureFile + "*", SearchOption.AllDirectories);
                        if (files.Length > 0)
                        {
                            string bigFile = files[0].FullName;
                            bigFile = bigFile.Substring(bigFile.IndexOf(AssetDirectory) + AssetDirectory.Length + 1);
                            
                            if (!FileList.Contains(bigFile))
                            {
                                //Console.WriteLine("\t\t" + bigFile);
                                FileList.Add(bigFile);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("ERROR: COULD NOT FIND SPECIFIED TEXTURE FILE IN CHOSEN ASSET DIRECTORY");
                        }
                    }
                    contents = contents.Substring(index + 1);
                    
                }

                

            }catch(DirectoryNotFoundException exception)
            {
                Console.WriteLine($"{s} not in this directory. Potentially apart of core or other directory");
            }
        }

        public void CopyFiles()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Asset Directory";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                OutputDirectory = fbd.SelectedPath;
            }

            FileList.RemoveAll(a => a == "\r");
            FileList.RemoveAll(a => a == " ");
            FileList.RemoveAll(a => a == "\n");

            for (int i = 0; i < FileList.Count; i++)
            {
                

                string fileName = FileList[i];

                fileName = fileName.Replace(".vmat", ".vmat_c");
                fileName = fileName.Replace(".vmdl", ".vmdl_c");
                fileName = fileName.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");

                string source = Path.Combine(AssetDirectory, fileName);
                string destination = Path.Combine(OutputDirectory, fileName);
                string directory = destination.Substring(0, destination.LastIndexOf("\\"));

                try
                {
                    if (File.Exists(source))
                    {
                        Directory.CreateDirectory(directory);
                        File.Copy(source, destination, true);
                    }
                    
                }
                catch (DirectoryNotFoundException exception)
                {
                    Console.WriteLine($"{source} cannot be copied to {destination} because the directory of the source file does not exist. \n Likely the file isn't in the provided asset directory. ");
                }
            }

        }
    }
}
