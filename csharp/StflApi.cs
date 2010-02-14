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
using System.Runtime.InteropServices;

namespace Mono.Stfl
{
	internal class StflApi
	{
        [DllImport("libstfl")]
        //internal static extern IntPtr stfl_create(IntPtr p);
        internal static extern IntPtr stfl_create(byte [] p);
        
        [DllImport("libstfl")]
        internal static extern void stfl_free(IntPtr form);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_run(IntPtr form, int timeout);
        
        [DllImport("libstfl")]
        internal static extern void stfl_reset();
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_get(IntPtr form, byte[] name);
        
        [DllImport("libstfl")]
        internal static extern void stfl_set(IntPtr form, byte[] name, byte[] val);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_focus(IntPtr form);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_quote(IntPtr text);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_dump(IntPtr form, IntPtr name, IntPtr prefix, int focus);
        
		[DllImport("libstfl")]
		internal static extern void stfl_modify(IntPtr f, byte[] name, byte[] mode, byte[] text);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_lookup(IntPtr f, IntPtr path, IntPtr newname);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_error();
        
        [DllImport("libstfl")]
        internal static extern void stfl_error_action(IntPtr mode);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_ipool_create(IntPtr code);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_ipool_add(IntPtr pool, IntPtr data);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_ipool_towc(IntPtr pool, IntPtr buf);
        
        [DllImport("libstfl")]
        internal static extern IntPtr stfl_ipool_fromwc(IntPtr pool, IntPtr buf);
        
        [DllImport("libstfl")]
        internal static extern void stfl_ipool_flush(IntPtr pool);
        
        [DllImport("libstfl")]
        internal static extern void stfl_ipool_destroy(IntPtr pool);
		
	    [DllImport("libstfl")]
        internal static extern IntPtr stfl_get_focus(IntPtr f);
	}
}
