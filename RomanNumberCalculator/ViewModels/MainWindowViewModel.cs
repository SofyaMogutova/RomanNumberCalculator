using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace RomanNumberCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		string text = "";
		string first;
		string second;
		string Operator = "";
		public MainWindowViewModel()
		{
			OnClickValue = ReactiveCommand.Create<string, string>((str) => Text += str);
			OnClick = ReactiveCommand.Create<string, string>((str) => Text = str);
		}

		public string Text
		{
			set
			{
				if ((value == "+" || value == "-" || value == "*" || value == "/") && Operator == "")
				{
					first = text;
					Operator = value;
					this.RaiseAndSetIfChanged(ref text, "");
				}
				else if (value == "=" && Operator != "")
				{
					second = text;
					var first_str = new RomanNumberExtend(first);
					var second_str = new RomanNumberExtend(second);


					switch (Operator)
					{
						case ("+"):
							value = (first_str + second_str).ToString();
							break;
						case ("-"):
							value = (first_str - second_str).ToString();
							break;
						case ("*"):
							value = (first_str * second_str).ToString();
							break;
						case ("/"):
							value = (first_str / second_str).ToString();
							break;
					}
					Operator = "";
					this.RaiseAndSetIfChanged(ref text, value);
				}
				else if ((value == "+" || value == "-" || value == "*" || value == "/") && Operator != "")
				{
					second = text;
					var first_str = new RomanNumberExtend(first);
					var second_str = new RomanNumberExtend(second);
					var k = value;

					switch (Operator)
					{
						case ("+"):
							first = (first_str + second_str).ToString();
							break;
						case ("-"):
							first = (first_str - second_str).ToString();
							break;
						case ("*"):
							first = (first_str * second_str).ToString();
							break;
						case ("/"):
							first = (first_str / second_str).ToString();
							break;
					}
					Operator = k;
					this.RaiseAndSetIfChanged(ref text, "");
				}
				else
					this.RaiseAndSetIfChanged(ref text, value);
			}
			get
			{
				return text;
			}
		}
		public ReactiveCommand<string, string> OnClickValue { get; }
		public ReactiveCommand<string, string> OnClick { get; }
	}
    
}
