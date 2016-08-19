using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamFormsReplTest.UITests
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
			app = AppInitializer.StartApp (platform);

			// REPL is ignored when running on the cloud
			//app.Repl ();
		}

		[Test]
		public void DummyTest()
		{
			app.Tap(p => p.Button("logInButton"));
			app.Tap(p => p.Button("button1"));
			app.EnterText(p => p.TextField("usernameEntry"), "George");
			app.EnterText(p => p.TextField("passwordEntry"), "aPassword");
			app.Tap(p => p.Button("logInButton"));
			Assert.IsTrue (true);
		}
	}
}

