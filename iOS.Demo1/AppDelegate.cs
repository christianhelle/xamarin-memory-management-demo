using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace iOS.Demo1
{
	[Register(nameof(AppDelegate))]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching(UIApplication application, 
                                               NSDictionary launchOptions)
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			var controller = new MainViewController();
			controller.Title = "Main";
			controller.View.BackgroundColor = UIColor.White;
			Window.RootViewController = new UINavigationController(controller);
			Window.MakeKeyAndVisible();
			return true;
		}
	}


	[Register(nameof(MainViewController))]
	public class MainViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var button = UIButton.FromType(UIButtonType.System);
			button.Frame = new CGRect((View.Bounds.Width - 200) / 2,
			                          (View.Bounds.Height - 25) / 2,
			                          200,
			                          25);
			button.SetTitle("Open me", UIControlState.Normal);
			button.TouchUpInside += OnButtonTapped;				
			View.Add(button);
		}

		private void OnButtonTapped(object sender, EventArgs e)
		{
            var controller = new SecondViewController();
            base.NavigationController.PushViewController(controller, true);
		}
	}


    [Register(nameof(SecondViewController))]
    public class SecondViewController : UIViewController
    {
        UIButton button, closeButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = "Second";

            button = UIButton.FromType(UIButtonType.System);
            button.Frame = new CGRect((View.Bounds.Width - 200) / 2,
                                      (View.Bounds.Height - 25) / 2,
                                      200,
                                      25);
            button.SetTitle("Click me!", UIControlState.Normal);
            Add(button);

            closeButton = UIButton.FromType(UIButtonType.System);
            closeButton.Frame = new CGRect((View.Bounds.Width - 200) / 2,
                                           button.Frame.Bottom + 20,
                                           200,
                                           25);
            closeButton.SetTitle("Pop me!", UIControlState.Normal);
            Add(closeButton);
        }

        #region ViewDidDisappear
        //public override void ViewDidDisappear(bool animated)
        //{
        //	base.ViewDidDisappear(animated);

        //	if (IsMovingFromParentViewController || IsBeingDismissed)
        //	{
        //		foreach (var view in View.Subviews)
        //		{
        //			view.RemoveFromSuperview();
        //			view.Dispose();
        //		}
        //	}
        //}
        #endregion

        #region Event Handlers
        private void OnButtonTapped(object sender, EventArgs e)
        {
            Console.WriteLine(sender.GetType() + " was tapped");
        }

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            NavigationController.PopViewController(true);
        }
        #endregion

        #region Dispose
        //protected override void Dispose(bool disposing)
        //{
        //    Console.WriteLine($"{GetType()} controller disposed - {GetHashCode()}");
        //    base.Dispose(disposing);
        //}
        #endregion
    }

    public class CompositeDisposable : List<IDisposable>, IDisposable
    {
        public void Dispose()
        {
            foreach (var item in this)
                item.Dispose();
            Clear();
        }
    }
}

