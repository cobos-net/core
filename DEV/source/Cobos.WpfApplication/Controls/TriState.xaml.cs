﻿// ============================================================================
// Filename: TriState.xaml.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cobos.WpfApplication.Controls
{
	public enum TriStateEnum
	{
		Yes = 0,
		No = 1,
		NA = 2
	}

	/// <summary>
	/// Interaction logic for TriState.xaml
	/// </summary>
	public partial class TriState : UserControl
	{
		public TriState()
		{
			InitializeComponent();
		}

		public TriStateEnum State
		{
			get
			{
				if ( _Yes.IsChecked.HasValue && _Yes.IsChecked.Value )
				{
					return TriStateEnum.Yes;
				}
				else if ( _No.IsChecked.HasValue && _No.IsChecked.Value )
				{
					return TriStateEnum.No;
				}
				else // _NA or nothing checked
				{
					return TriStateEnum.NA;
				}
			}

			set
			{
				switch ( value )
				{
				case TriStateEnum.Yes:
					_Yes.IsChecked = true;
					break;

				case TriStateEnum.No:
					_No.IsChecked = true;
					break;

				case TriStateEnum.NA:
				default:
					_NA.IsChecked = true;
					break;
				}
			}
		}
		
	}
}
