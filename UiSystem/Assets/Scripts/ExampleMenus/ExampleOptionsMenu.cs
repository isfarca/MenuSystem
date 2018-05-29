public class ExampleOptionsMenu : Menu<ExampleOptionsMenu>
{
    /// <summary>
    /// Open the options menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the options menu.
    /// </summary>
    public static void Hide()
    {
        Close();
    }

    /// <summary>
    /// Open the simple menu and close the options menu.
    /// </summary>
    public void BackToSimpleMenu()
    {
        ExampleSimpleMenu.Open();

        Hide();
    }
}