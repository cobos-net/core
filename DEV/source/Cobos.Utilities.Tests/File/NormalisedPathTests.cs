﻿// ============================================================================
// Filename: NormalisedPathTests.cs
// Description: 
// ----------------------------------------------------------------------------
// Created by: N.Davis                          Date: 21-Nov-09
// Updated by:                                  Date:
// ============================================================================
// Copyright (c) 2009-2012 Nicholas Davis		nick@cobos.co.uk
//
// Cobos Software Development Kit
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ============================================================================

using System;
using NUnit.Framework;
using Cobos.Utilities.File;

namespace Cobos.Utilities.Tests.File
{
	[TestFixture]
	public class NormalisedPathTests
	{
		[TestCase]
		public void Same_normalised_file_paths_are_the_same()
		{
			string path1 = @"C:\file\  location  \\   \\  \\without\any\relative\paths\\\\\\\\\file.txt";
			string path2 = @"C:\file\.\location\  \\\\    .\without\\\\.   \.\any\relative\.\.\   .\.   \   .  \.\paths\.\file.txt";

			// jumble the paths up a bit
			path1 = path1.Replace( '\\', '/' );
			path2 = path2.ToUpper();

			NormalisedPath npath1 = new NormalisedPath( path1 );
			NormalisedPath npath2 = new NormalisedPath( path2 );

			Assert.True( npath1 == npath2 );

			string path3 = @"C:\file\location\..\location\without\\ \ \\any\..\..\  without   \\\\\\\\\any\relative  \  paths\    ..\..   \   ..    \any\relative\paths\file.txt";
			string path4 = path3;

			NormalisedPath npath3 = new NormalisedPath( path3 );

			Assert.True( npath1 == npath3 );

			// jumble it up a bit
			path4 = path4.Replace( '\\', '/' );
			path4 = path4.ToUpper();

			NormalisedPath npath4 = new NormalisedPath( path4 );
			
			Assert.True( npath1 == npath4 );

			// compare them all...
			Assert.True( npath1 == npath2 && npath1 == npath3 && npath1 == npath4 && npath2 == npath3 && npath2 == npath4 && npath3 == npath4 );

			// compare relative paths
			string folderpath = @"C:\file\  location  \\   \\  \\without\any\relative\paths";

			NormalisedPath rpath1 = new NormalisedPath( "file.txt", folderpath );

			Assert.True( npath1 == rpath1 );

			string path5 = @"..\..\..\any\relative\paths\file.txt";

			// jumble it up
			path5 = path5.Replace( '\\', '/' );
			path5 = path5.ToUpper();

			NormalisedPath rpath2 = new NormalisedPath( path5, folderpath );

			// compare them all
			Assert.True( rpath1 == rpath2 && npath1 == rpath2 );
		}

		[TestCase]
		public void Can_handle_empty_paths()
		{
			NormalisedPath empty = null;

			Assert.DoesNotThrow( delegate { empty = new NormalisedPath( "" ); } );
			Assert.True( empty.IsNullPath );

			Assert.DoesNotThrow( delegate { empty = new NormalisedPath( "            " ); } );
			Assert.True( empty.IsNullPath );

			Assert.DoesNotThrow( delegate { empty = new NormalisedPath( "\"\"" ); } );
			Assert.True( empty.IsNullPath );

			Assert.DoesNotThrow( delegate { empty = new NormalisedPath( "       \"      \"          " ); } );
			Assert.True( empty.IsNullPath );

			Assert.DoesNotThrow( delegate { empty = new NormalisedPath( "       \"      \"          " ); } );
			Assert.True( empty.IsNullPath );

			Assert.DoesNotThrow( delegate { empty = new NormalisedPath( "  \\  '   \"    \\  \"    \" \"  ' /   '  " ); } );
			Assert.True( empty.IsNullPath );
		}

		[TestCase]
		public void Can_get_path_components()
		{
			string path = @"C:\file\location\..\location\without\\ \ \\any\..\..\  without   \\\\\\\\\any\relative  \  paths\    ..\..   \   ..    \any\relative\paths\file.txt";
			NormalisedPath npath = new NormalisedPath( path );

			Assert.AreEqual( @"c:\file\location\without\any\relative\paths", npath.GetDirectoryName().Value );
			Assert.AreEqual( @"file.txt", npath.GetFileName() );
			Assert.AreEqual( @"file", npath.GetFileNameWithoutExtension() );
			Assert.AreEqual( @".txt", npath.GetExtension() );
		}

	}
}
