using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text.Style;
using Android.Text;

namespace Android.Demo1
{
    [Activity(Label = "Android Demo", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += (sender, e) => StartActivity(typeof(SecondActivity));
        }
    }


    [Activity]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Second);

            var button = FindViewById<Button>(Resource.Id.closeButton);
            button.Click += (sender, e) => Finish();

            var imageSpan = new ImageSpan(Application.Context, Resource.Mipmap.Icon);
            var spannableString = new SpannableString("  Close");
            spannableString.SetSpan(imageSpan, 0, 1, 0);
            button.SetText(spannableString, TextView.BufferType.Spannable);
        }
    }
}

