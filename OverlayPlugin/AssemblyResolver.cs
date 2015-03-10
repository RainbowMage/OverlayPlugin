using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    class AssemblyResolver : IDisposable
    {
        static readonly Regex assemblyNameParser = new Regex(
            @"(?<name>.+?), Version=(?<version>.+?), Culture=(?<culture>.+?), PublicKeyToken=(?<pubkey>.+)",
            RegexOptions.Compiled);

        public string Directory { get; set; }

        public AssemblyResolver(string directory)
        {
            this.Directory = directory;
            AppDomain.CurrentDomain.AssemblyResolve += CustomAssemblyResolve;
        }

        public void Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CustomAssemblyResolve;
        }

        private Assembly CustomAssemblyResolve(object sender, ResolveEventArgs e)
        {
            // Directory プロパティで指定されたディレクトリを基準にアセンブリを検索する
            var asmPath = "";
            var match = assemblyNameParser.Match(e.Name);
            if (match.Success)
            {
                var asmFileName = match.Groups["name"].Value + ".dll";
                if (match.Groups["culture"].Value == "neutral")
                {
                    asmPath = Path.Combine(Directory, asmFileName);
                }
                else
                {
                    asmPath = Path.Combine(Directory, match.Groups["culture"].Value, asmFileName);
                }
            }
            else
            {
                asmPath = Path.Combine(Directory, e.Name + ".dll");
            }

            if (File.Exists(asmPath))
            {
                return Assembly.LoadFile(asmPath);
            }

            return null;
        }

        private Assembly GetAssembly(string path)
        {
            try
            {
                var result = Assembly.LoadFrom(path);
                return result;
            }
            catch (Exception e)
            {
                OnExceptionOccured(e);
            }

            return null;
        }

        protected void OnExceptionOccured(Exception exception)
        {
            if (this.ExceptionOccured != null)
            {
                this.ExceptionOccured(this, new ExceptionOccuredEventArgs(exception));
            }
        }

        public event EventHandler<ExceptionOccuredEventArgs> ExceptionOccured; 

        public class ExceptionOccuredEventArgs : EventArgs
        {
            public Exception Exception {get; set;}
            public ExceptionOccuredEventArgs(Exception exception)
            {
                this.Exception = exception;
            }
        }
    }
}
