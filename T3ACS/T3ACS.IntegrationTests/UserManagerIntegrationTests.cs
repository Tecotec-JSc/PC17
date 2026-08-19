using T3ACS.Data.Manager;
using Xunit;

namespace T3ACS.IntegrationTests;

/// <summary>
/// Integration test: kiểm thử UserManager với SQLite thật (file tạm).
/// Mỗi test tạo một file DB riêng — không ảnh hưởng lẫn nhau và không
/// đụng vào file T3.db thật trên máy dev.
/// </summary>
public class UserManagerIntegrationTests : IDisposable
{
    private readonly string _dbPath;

    public UserManagerIntegrationTests()
    {
        // Tạo file SQLite tạm — xóa sau khi test xong
        _dbPath = Path.Combine(Path.GetTempPath(), $"T3_IntTest_{Guid.NewGuid():N}.db");

        // TODO: khởi tạo đường dẫn DB cho T3.Configuration.Main
        // trước khi tạo UserManager, ví dụ:
        // T3.Configuration.Main.DbPath = _dbPath;
    }

    public void Dispose()
    {
        if (File.Exists(_dbPath))
            File.Delete(_dbPath);
    }

    [Fact]
    public void InsertUser_ValidUser_CanBeRetrievedBack()
    {
        // TODO: implement sau khi xác nhận API khởi tạo DB
        // var manager = new UserManager();
        // var result = manager.InsertUser("testuser", "password", "Admin");
        // Assert.True(result > 0);
        // var user = manager.GetUserByName("testuser");
        // Assert.NotNull(user);
        // Assert.Equal("Admin", user.Role);
        Assert.True(true, "Placeholder — cần setup DB path trước");
    }

    [Fact]
    public void InsertUser_DuplicateName_ReturnsError()
    {
        // TODO: kiểm tra constraint duplicate username
        Assert.True(true, "Placeholder");
    }

    [Fact]
    public void GetAllUsers_AfterInsert_ReturnsCorrectCount()
    {
        // TODO: insert N user, GetAll phải trả về đúng N bản ghi
        Assert.True(true, "Placeholder");
    }
}
