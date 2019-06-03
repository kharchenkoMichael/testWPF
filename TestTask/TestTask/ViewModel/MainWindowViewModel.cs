using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace TestTask
{
    public class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            ShowWindow = new RelayCommand(ShowNewWindow);
            CloseWindow = new RelayCommand(ClsoeNewWindow);
        }

        public RelayCommand ShowWindow { get; private set; }
        public RelayCommand CloseWindow { get; private set; }

        public void ShowNewWindow()
        {
            // пользовательская логика

            // Отправка сообщение через медиатор. Сообщение получат все объекты, которые зарегистрировались на получение сообщений строкового типа.
            Messenger.Default.Send<string>("show");
        }

        public void ClsoeNewWindow()
        {
            // пользовательская логика
            Messenger.Default.Send("main close");
        }
    }
}
