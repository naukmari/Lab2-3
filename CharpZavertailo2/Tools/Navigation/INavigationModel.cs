namespace CharpZavertailo2.Tools.Navigation
{
    internal enum ViewType
    {
        PersonFillInfo,
        Main
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
