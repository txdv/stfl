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
using Mono.Stfl;

public class MainApp
{
    public static void Main(string [] args)
    {
        Form f = new Form("<example.stfl>");
        f["value_a"] = "Ačių jum (Lithuanian symbols!)";
        f["value_b"] = "Test for STFL";
        

        string ret = "";
        while (ret != "ESC")
        {
          ret = f.Run(500);
        }
            
        Form.ResetConsole();
        Console.WriteLine("A: {0}", f["value_a"]);
        Console.WriteLine("B: {0}", f["value_b"]);
        f.Dispose();
    }
}

