using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;

namespace Mobile.Droid
{
    [Activity(Label = "Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            DeployDatabaseFromAssetsAsync();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            XF.Material.Droid.Material.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void DeployDatabaseFromAssetsAsync()
        {
            var databaseName = "phone.db";

            // Android application default folder.
            var appFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var dbFile = Path.Combine(appFolder, databaseName);

            // Check if the file already exists.
            if (!File.Exists(dbFile))
            {
                using (FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    // Assets is comming from the current context.
                    this.Assets.Open(databaseName).CopyTo(writeStream);
                }
            }
        }
    }
}