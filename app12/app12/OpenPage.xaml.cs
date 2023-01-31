using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app12
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OpenPage : ContentPage
	{
		public OpenPage (Student student)
		{
			InitializeComponent ();
            this.BindingContext = student;
        }
	}
}