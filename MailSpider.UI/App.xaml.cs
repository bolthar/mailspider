using System.Windows;

namespace MailSpider.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainPresentationModel mainPresentationModel = new MainPresentationModel(new Main());
            mainPresentationModel.View.Show();
        }
    }
}
