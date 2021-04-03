using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class NotifyViewModelBase<T>
    {
        public List<T> Items { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool Irouting { get; set; }
        public string RootUrl { get; set; }
        public int RedirectTimeOut { get; set; }
        public NotifyViewModelBase()
        {
            Header = "Yönlendiriliyorsunuz";
            Title = "Geçersiz İşlem";
            Irouting = true;
            RootUrl = "/Home/Index";
            RedirectTimeOut = 10000;
        }
    }
}