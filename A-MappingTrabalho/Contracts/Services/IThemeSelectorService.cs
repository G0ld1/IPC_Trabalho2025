using System;

using A_MappingTrabalho.Models;

namespace A_MappingTrabalho.Contracts.Services
{
    public interface IThemeSelectorService
    {
        bool SetTheme(AppTheme? theme = null);

        AppTheme GetCurrentTheme();
    }
}
