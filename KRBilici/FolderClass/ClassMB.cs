using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KRBilici.FolderClass
{
    class ClassMB
    {
        public static void MBError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MBError(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MBInformation(string text)
        {
            MessageBox.Show(text, "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void MessageQuestionExit()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно" +
                "хотите выйти?", "Вопрос", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
