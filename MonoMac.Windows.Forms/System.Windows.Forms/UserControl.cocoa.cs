// 
//  Copyright 2011  James Clancey
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.using System;
using System.Collections;
using System.Linq;
using MonoMac.AppKit; // using AppKit;
using System.Drawing;
using MonoMac.Foundation; // using Foundation;

namespace System.Windows.Forms
{
    // ankr TODO
    internal abstract class UserControlMouseView : UserControl
    {
        public abstract bool IsFlipped { get; }
    }

    internal partial class InternalUserControl : UserControlMouseView, IControl
    {
        public new string Text { get; set; }

        public override bool IsFlipped
        {
            get
            {
                return true;
            }
        }

    }
}

