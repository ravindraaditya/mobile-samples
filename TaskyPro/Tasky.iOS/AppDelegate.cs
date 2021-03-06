using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Tasky {
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		UITableViewController homeViewController;
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
	
            // create our nav controller
			navController = new UINavigationController ();
            navController.Title = "Tasky Pro";

			// create our home controller based on the device
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				homeViewController = new Tasky.Screens.iPhone.HomeScreen();
			} else {
				homeViewController = new Tasky.Screens.iPhone.HomeScreen(); // TODO: replace with iPad screen if we implement for iPad
			}
			
			// Styling
			UINavigationBar.Appearance.TintColor = UIColor.FromRGB (38, 117 ,255); // nice blue
			UITextAttributes ta = new UITextAttributes();
			ta.Font = UIFont.FromName ("AmericanTypewriter-Bold", 0f);
			UINavigationBar.Appearance.SetTitleTextAttributes(ta);
			ta.Font = UIFont.FromName ("AmericanTypewriter", 0f);
			UIBarButtonItem.Appearance.SetTitleTextAttributes(ta, UIControlState.Normal);
			

			// push the view controller onto the nav controller and show the window
			navController.PushViewController(homeViewController, false);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}