namespace CrudWeb.Layout;

using MudBlazor;
using MudBlazor.Utilities;

public sealed class CrudWebPalette : PaletteDark
{

    private CrudWebPalette()
    {
        Primary = new MudColor("#9966FF");
        Warning = new MudColor("#d9534f");
        Secondary = new MudColor("#F6AD31");
        Tertiary = new MudColor("#8AE491");
    }

    public static CrudWebPalette CreatePallette => new();
}
