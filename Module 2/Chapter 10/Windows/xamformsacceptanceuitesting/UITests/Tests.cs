using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamFormsAcceptanceUITesting.UITests
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			// Arrange
			app = AppInitializer.StartApp (platform);

			// REPL is ignored when running in the cloud.
//			app.Repl ();
		}

		[Test]
		public void Add_Contact_Button_Should_Navigate_To_Contact_Page ()
		{
			// Act
			app.Screenshot ("MainPage screen.");
			app.Tap (p => p.Button ("addContactButton"));
			AppResult[] results = app.Query (p => p.Marked ("addContactPage"));

			// Assert
			Assert.True (results.Any());
		}

		[Test]
		public void Save_Contact_Button_Should_Navigate_Back_To_MainPage()
		{
			// Act
			app.Screenshot ("MainPage screen."); // Screenshot names are only supported in Test Cloud.
			app.Tap (p => p.Button ("addContactButton"));
			app.WaitForElement (p => p.Marked ("addContactPage"));
			app.EnterText (p => p.Marked ("nameEditText"), "George Taskos");
			app.EnterText (p => p.Marked ("emailEditText"), "george@xplatsolutions.com");
			app.Tap (p => p.Button ("saveButton"));
			app.WaitForElement (p => p.Marked ("mainPage"));
			AppResult[] results = app.Query (p => p.Marked ("mainPage"));

			// Assert
			Assert.True (results.Any());
		}
	}
}