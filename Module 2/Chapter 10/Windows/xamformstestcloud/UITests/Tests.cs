using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamFormsTestCloud.UITests
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
		}

		[Test]
		public void Should_Navigate_To_Details_And_Back_To_MainPage ()
		{
			// Act
			app.Screenshot ("On mainPage");
			app.Tap(p => p.Button("detailsPageButton"));
			app.WaitForElement(p => p.Marked("detailsPage"));
			app.Screenshot ("Navigated to detailsPage");
			app.WaitForElement(p => p.Marked("mainPageButton"));
			app.Tap(p => p.Button("mainPageButton"));
			AppResult[] results = app.WaitForElement(p => p.Marked("mainPage"));
			app.Screenshot ("Navigated back to mainPage");

			// Assert
			Assert.True(results.Any());
		}
	}
}

