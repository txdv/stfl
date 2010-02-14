//  
//  Copyright (C) 2010 Andrius Bentkus
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using System.IO;
using System.Text;
using System.Reflection;
using Mono.Unix;

namespace Mono.Stfl
{
	public class Form : IDisposable
	{
		private IntPtr handleForm;
		
		public Form(string text)
		{
			handleForm = StflApi.stfl_create(text);
		}
		
        public Form(Assembly assembly, string resourceName)
        {
            if (assembly == null) {
                assembly = Assembly.GetCallingAssembly();
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream)) {
                if (stream == null) {
                    throw new ArgumentException(resourceName + " could not be found in assembly", "resourceName");
                }
                string text = reader.ReadToEnd();
                if (String.IsNullOrEmpty(text)) {
                    throw new ArgumentException(resourceName + " in assembly is missing or empty.", "resourceName");
                }
                handleForm = StflApi.stfl_create(text);
            }
        }
        
		public string this[string name]
		{
			get
			{
				return StflApi.stfl_get(handleForm, name);
			}
			set 
			{
				StflApi.stfl_set(handleForm, name, value);
			}
		}
        
		public virtual string Run(int timeout)
		{
			return StflApi.stfl_run(handleForm, timeout);
		}
		
        public virtual void Dispose()
        {
			StflApi.stfl_free(handleForm);
		}
		
		public void Modify(string name, string mode, string text)
        {
			StflApi.stfl_modify(handleForm, name , mode, text);
        }
		
		public static void ResetConsole()
		{
			StflApi.stfl_reset();
		}
        
        public string GetFocus()
        {
            return StflApi.stfl_get_focus(handleForm);
        }
        
        public void SetFocus(string name)
        {
            StflApi.stfl_set_focus(handleForm, name);
        }
		
	}
}
