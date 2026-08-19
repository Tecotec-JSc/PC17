using VSat.FormulaEvaluator;
using Xunit;

namespace T3ACS.Tests;

/// <summary>
/// Kiểm thử engine tính biểu thức công thức (Evaluator / ExpressionParser).
/// Mỗi test dùng file tạm độc lập — không ảnh hưởng lẫn nhau.
/// </summary>
public class EvaluatorTests : IDisposable
{
    private readonly string _formulaFile;

    public EvaluatorTests()
    {
        _formulaFile = Path.GetTempFileName();
    }

    public void Dispose()
    {
        if (File.Exists(_formulaFile))
            File.Delete(_formulaFile);
    }

    // Ghi công thức ra file tạm rồi gọi Calculate — tránh lặp code ở mỗi test.
    private List<object> RunFormula(string content, Dictionary<string, double> inputs)
    {
        File.WriteAllText(_formulaFile, content);
        return Evaluator.Calculate(_formulaFile, inputs);
    }

    /// <summary>
    /// Phép tính số học cơ bản: cộng và nhân với giá trị dương.
    /// a=10, b=3, c=2 → result = a + b * c = 10 + 6 = 16
    /// </summary>
    [Fact]
    public void Calculate_BasicArithmetic_ReturnsCorrectResult()
    {
        var formula = "INPUT: a, b, c\nresult = a + b * c\nOUTPUT: result";
        var inputs = new Dictionary<string, double> { ["a"] = 10, ["b"] = 3, ["c"] = 2 };

        var results = RunFormula(formula, inputs);

        Assert.Single(results);
        Assert.Equal(16.0, (double)results[0], precision: 10);
    }

    /// <summary>
    /// Ưu tiên toán tử: nhân phải được tính trước cộng.
    /// 1 + 2 * 3 phải bằng 7, không phải (1+2)*3 = 9.
    /// </summary>
    [Fact]
    public void Calculate_OperatorPrecedence_MultiplicationBeforeAddition()
    {
        var formula = "INPUT: x, y, z\nresult = x + y * z\nOUTPUT: result";
        var inputs = new Dictionary<string, double> { ["x"] = 1, ["y"] = 2, ["z"] = 3 };

        var results = RunFormula(formula, inputs);

        Assert.Equal(7.0, (double)results[0], precision: 10);
    }

    /// <summary>
    /// Hàm sqrt tích hợp phải trả về căn bậc hai chính xác.
    /// sqrt(16) = 4.0
    /// </summary>
    [Fact]
    public void Calculate_SqrtFunction_ReturnsSquareRoot()
    {
        var formula = "INPUT: n\nresult = sqrt(n)\nOUTPUT: result";
        var inputs = new Dictionary<string, double> { ["n"] = 16 };

        var results = RunFormula(formula, inputs);

        Assert.Equal(4.0, (double)results[0], precision: 10);
    }

    /// <summary>
    /// Chia cho 0 phải ném DivideByZeroException thay vì trả về Infinity.
    /// Đảm bảo engine không cho kết quả sai im lặng khi step Calculation gặp mẫu số = 0.
    /// </summary>
    [Fact]
    public void Calculate_DivisionByZero_ThrowsDivideByZeroException()
    {
        var formula = "INPUT: a, b\nresult = a / b\nOUTPUT: result";
        var inputs = new Dictionary<string, double> { ["a"] = 10, ["b"] = 0 };
        File.WriteAllText(_formulaFile, formula);

        Assert.Throws<DivideByZeroException>(() => Evaluator.Calculate(_formulaFile, inputs));
    }

    /// <summary>
    /// Tham chiếu đến biến chưa được khai báo phải ném KeyNotFoundException.
    /// Tránh trường hợp engine trả về 0 im lặng khiến kết quả đo sai mà không có cảnh báo.
    /// </summary>
    [Fact]
    public void Calculate_UndeclaredVariable_ThrowsKeyNotFoundException()
    {
        var formula = "INPUT: a\nresult = a + bien_chua_khai_bao\nOUTPUT: result";
        var inputs = new Dictionary<string, double> { ["a"] = 5 };
        File.WriteAllText(_formulaFile, formula);

        Assert.Throws<KeyNotFoundException>(() => Evaluator.Calculate(_formulaFile, inputs));
    }
}
