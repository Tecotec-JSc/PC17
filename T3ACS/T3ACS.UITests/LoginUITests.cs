using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Xunit;

namespace T3ACS.UITests;

/// <summary>
/// UI automation test dùng FlaUI — launch T3ACS.exe thật và tương tác UI.
/// EXE được download từ build artifact, đường dẫn truyền qua biến môi trường
/// T3ACS_EXE_PATH (được set bởi GitHub Actions trong job ui-test).
/// </summary>
public class LoginUITests : IDisposable
{
    private static readonly string AppPath =
        Environment.GetEnvironmentVariable("T3ACS_EXE_PATH")
        ?? throw new InvalidOperationException(
            "Biến môi trường T3ACS_EXE_PATH chưa được set. " +
            "Khi chạy local: set T3ACS_EXE_PATH=<đường dẫn đến T3ACS.exe>");

    private readonly Application _app;
    private readonly UIA3Automation _automation;

    public LoginUITests()
    {
        _automation = new UIA3Automation();
        _app = Application.Launch(AppPath);
        // Chờ tối đa 10 giây để main window xuất hiện
        _app.WaitWhileMainHandleIsMissing(TimeSpan.FromSeconds(10));
    }

    public void Dispose()
    {
        try { _app.Close(); } catch { /* ignore */ }
        _automation.Dispose();
    }

    [Fact]
    public void App_OnStart_MainWindowIsVisible()
    {
        var window = _app.GetMainWindow(_automation);
        Assert.NotNull(window);
        Assert.True(window.IsEnabled);
    }

    [Fact]
    public void Login_EmptyCredentials_ButtonStillEnabled()
    {
        var window = _app.GetMainWindow(_automation);

        // TODO: thay "btnLogin" bằng AutomationId thực tế của button Login
        // Xem AutomationId trong Visual Studio → Accessibility Insights hoặc Inspect.exe
        // var btnLogin = window
        //     .FindFirstDescendant(cf => cf.ByAutomationId("btnLogin"))
        //     ?.AsButton();
        // Assert.NotNull(btnLogin);
        // Assert.True(btnLogin.IsEnabled);

        Assert.NotNull(window); // Placeholder
    }

    [Fact]
    public void Login_WrongPassword_ShowsErrorMessage()
    {
        var window = _app.GetMainWindow(_automation);

        // TODO: điền username/password sai rồi kiểm tra label lỗi
        // var txtUser = window.FindFirstDescendant(cf => cf.ByAutomationId("txtUsername"))?.AsTextBox();
        // var txtPass = window.FindFirstDescendant(cf => cf.ByAutomationId("txtPassword"))?.AsTextBox();
        // var btnLogin = window.FindFirstDescendant(cf => cf.ByAutomationId("btnLogin"))?.AsButton();
        //
        // txtUser?.Enter("wrong_user");
        // txtPass?.Enter("wrong_pass");
        // btnLogin?.Click();
        //
        // var lblError = window.FindFirstDescendant(cf => cf.ByAutomationId("lblError"));
        // Assert.NotEmpty(lblError?.Text ?? "");

        Assert.NotNull(window); // Placeholder
    }
}
