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
using System.Text;
using Mono.Unix;

namespace Mono.Stfl
{
	public class Form : IDisposable
	{
		private IntPtr handleForm;
		
		public Form(string text)
		{
			handleForm = StflApi.stfl_create(GetBytes(text));
		}
		
		public string this[string name]
		{
			get
			{
				IntPtr ptr = StflApi.stfl_get(handleForm, GetBytes(name));
				string ret = UnixMarshal.PtrToString(ptr, Encoding.UTF32);
				return ret;
			}
			set 
			{
				StflApi.stfl_set(handleForm, 
				                 GetBytes(name),
				                 GetBytes(value)
				                 );
			}
		}
		
		public virtual string Run(int timeout)
		{
			IntPtr ptr = StflApi.stfl_run(handleForm, timeout);
		    return UnixMarshal.PtrToString(ptr, Encoding.UTF32);
		}
		
        public virtual void Dispose()
        {
			StflApi.stfl_free(handleForm);
		}
		
		public void Modify(string name, string mode, string text)
        {
			StflApi.stfl_modify(
			                    handleForm,
				                GetBytes(name),
				                GetBytes(mode),
								GetBytes(text)
			                    );
        }
		
		public static void ResetConsole()
		{
			StflApi.stfl_reset();
		}
		
		
		private byte[] GetBytes(string text)
		{
			byte[] textBytes = Encoding.UTF32.GetBytes(text);
			// HACK: we pass wchar_t* to C in a byte[] which terminates the
			// array using a single 0 byte, so we have to add 3 more
			byte[] bytes = new byte[textBytes.Length + 3];
			textBytes.CopyTo(bytes, 0);
			return bytes;
		}
	}
}
