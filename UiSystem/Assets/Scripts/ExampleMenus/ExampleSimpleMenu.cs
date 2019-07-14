public class ExampleSimpleMenu : Menu<ExampleSimpleMenu>
{
    /// <summary>
    /// Open the simple menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the simple menu.
    /// </summary>
    public static void Hide()
    {
        Close();
    }

    /// <summary>
    /// Open the options menu.
    /// </summary>
    public void ShowOptionsMenu()
    {
        Hide();
        ExampleOptionsMenu.Show();
    }
}