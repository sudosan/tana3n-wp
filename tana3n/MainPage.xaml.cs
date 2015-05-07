using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using CoreTweet;
using Windows.Storage;
using Windows.UI.Popups;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=391641 を参照してください

namespace tana3n
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。
        /// このプロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: ここに表示するページを準備します。

            // TODO: アプリケーションに複数のページが含まれている場合は、次のイベントの
            // 登録によりハードウェアの戻るボタンを処理していることを確認してください:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed イベント。
            // 一部のテンプレートで指定された NavigationHelper を使用している場合は、
            // このイベントが自動的に処理されます。
        }

        public CoreTweet.OAuth.OAuthSession session;
        public CoreTweet.Tokens token;

        int counter;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            string gay = "tana3n is gay(" + counter.ToString() + "回目)";
            token.Statuses.UpdateAsync(status => gay);
            text.Text = gay;
            ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
            container.Values["gay"] = counter.ToString(); ;
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            token = Tokens.Create(twitter.CK, twitter.CS, twitter.AT, twitter.ATS);
            var dialog = new MessageDialog("Loading complete!");
            await dialog.ShowAsync();

            ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
            if (container.Values.ContainsKey("gay"))
            {
                counter = Convert.ToInt32(container.Values["gay"].ToString());
            }
            else
            {
                counter = 0;
            }
        }


        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.SoundGoo.Play();
        }
    }
}
