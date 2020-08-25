using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Анализ статистики CV19";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов!";
        /// <summary>Статус бар</summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

    }
}
