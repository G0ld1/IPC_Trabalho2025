using System;
using System.Windows.Controls;

namespace A_MappingTrabalho.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
