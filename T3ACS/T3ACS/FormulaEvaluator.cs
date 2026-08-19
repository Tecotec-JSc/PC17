namespace VSat.FormulaEvaluator
{
    public static class Evaluator
    {

        private static string _customDllDir = null;

        public static void SetDllDirectory(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                _customDllDir = path;
            }
        }

        private static string GetFormulaFilePath()
        {
            string dllDir = _customDllDir;
            if (string.IsNullOrEmpty(dllDir) || !System.IO.Directory.Exists(dllDir))
            {
                string dllPath = typeof(Evaluator).Assembly.Location;
                dllDir = System.IO.Path.GetDirectoryName(dllPath);
            }

            if (string.IsNullOrEmpty(dllDir))
            {
                dllDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Dll");
                if (!System.IO.Directory.Exists(dllDir))
                {
                    dllDir = System.AppDomain.CurrentDomain.BaseDirectory;
                }
            }

            var candidates = new[] { "calculatedistance.txt", "calculatedistance", "dynamic_formula_sample.txt", "formula.txt" };
            foreach (var candidate in candidates)
            {
                string path = System.IO.Path.Combine(dllDir, candidate);
                if (System.IO.File.Exists(path)) return path;
            }

            if (System.IO.Directory.Exists(dllDir))
            {
                var txtFiles = System.IO.Directory.GetFiles(dllDir, "*.txt");
                if (txtFiles.Length > 0) return txtFiles[0];
            }

            throw new System.IO.FileNotFoundException($"No formula file (.txt) found in the same directory as the DLL: {dllDir}");
        }

        public static List<object> GetInputVariables() => GetInputVariables(GetFormulaFilePath());
        public static List<object> GetOutputVariables() => GetOutputVariables(GetFormulaFilePath());
        public static List<object> GetVariables() => GetVariables(GetFormulaFilePath());
        public static void WriteInputValues(List<object> inputValues) => WriteInputValues(GetFormulaFilePath(), inputValues);
        public static List<object> Calculate() => Calculate(GetFormulaFilePath());
        public static double Evaluate(System.Collections.Generic.Dictionary<string, double> inputs) => Evaluate(GetFormulaFilePath(), inputs);

        private static (string name, string unit, double? min, double? max) ParseVariableDetails(string entry)
        {
            entry = entry.Trim();
            double? min = null;
            double? max = null;

            int openCurly = entry.IndexOf('{');
            int closeCurly = entry.IndexOf('}');
            if (openCurly >= 0 && closeCurly > openCurly)
            {
                string rangeStr = entry.Substring(openCurly + 1, closeCurly - openCurly - 1).Trim();
                entry = (entry.Substring(0, openCurly) + entry.Substring(closeCurly + 1)).Trim();

                var rangeParts = rangeStr.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (rangeParts.Length >= 2)
                {
                    if (double.TryParse(rangeParts[0].Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double parsedMin))
                    {
                        min = parsedMin;
                    }
                    if (double.TryParse(rangeParts[1].Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double parsedMax))
                    {
                        max = parsedMax;
                    }
                }
            }

            int openParen = entry.IndexOf('(');
            int openBracket = entry.IndexOf('[');

            int idx = -1;
            char closeChar = '\0';
            if (openParen >= 0 && (openBracket < 0 || openParen < openBracket))
            {
                idx = openParen;
                closeChar = ')';
            }
            else if (openBracket >= 0)
            {
                idx = openBracket;
                closeChar = ']';
            }

            string name = entry;
            string unit = "";

            if (idx >= 0)
            {
                name = entry.Substring(0, idx).Trim();
                int closeIdx = entry.IndexOf(closeChar, idx);
                if (closeIdx > idx)
                {
                    unit = entry.Substring(idx + 1, closeIdx - idx - 1).Trim();
                }
                else
                {
                    unit = entry.Substring(idx + 1).Trim();
                }
            }

            return (name, unit, min, max);
        }

        private static (string name, string unit) ParseVariableAndUnit(string entry)
        {
            var parsed = ParseVariableDetails(entry);
            return (parsed.name, parsed.unit);
        }

        /// <summary>
        /// Reads the formula file and returns a list of INPUT variable names.
        /// </summary>
        public static List<object> GetInputVariables(string formulaFilePath)
        {
            var result = new List<object>();
            foreach (var line in ReadLines(formulaFilePath))
            {
                var t = line.Trim();
                if (t.StartsWith("INPUT:", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = t.Substring(6)
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        var parsed = ParseVariableAndUnit(part);
                        if (!string.IsNullOrEmpty(parsed.name))
                            result.Add(parsed.name);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Reads the formula file and returns a list of OUTPUT variable names.
        /// </summary>
        public static List<object> GetOutputVariables(string formulaFilePath)
        {
            var result = new List<object>();
            foreach (var line in ReadLines(formulaFilePath))
            {
                var t = line.Trim();
                if (t.StartsWith("OUTPUT:", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = t.Substring(7)
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        var parsed = ParseVariableAndUnit(part);
                        if (!string.IsNullOrEmpty(parsed.name))
                            result.Add(parsed.name);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Reads the formula file and returns a list of variables (both INPUT and OUTPUT).
        /// Each element in the returned list is an object[] representing:
        /// [0]: Variable name (Name)
        /// [1]: Variable type (Type: "Input" or "Output")
        /// [2]: Unit (Unit)
        /// [3]: Min value (Min - double?)
        /// [4]: Max value (Max - double?)
        /// </summary>
        public static List<object> GetVariables(string formulaFilePath)
        {
            var result = new List<object>();
            var lines = ReadLines(formulaFilePath);
            foreach (var line in lines)
            {
                var t = line.Trim();
                if (t.StartsWith("INPUT:", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = t.Substring(6)
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        var parsed = ParseVariableDetails(part);
                        if (!string.IsNullOrEmpty(parsed.name))
                            result.Add(new object[] { parsed.name, "Input", parsed.unit, parsed.min, parsed.max });
                    }
                }
            }

            foreach (var line in ReadLines(formulaFilePath))
            {
                var t = line.Trim();
                if (t.StartsWith("OUTPUT:", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = t.Substring(7)
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        var parsed = ParseVariableDetails(part);
                        if (!string.IsNullOrEmpty(parsed.name))
                            result.Add(new object[] { parsed.name, "Output", parsed.unit, parsed.min, parsed.max });
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Writes input variable values to the formula file.
        /// Accepts a List &lt;object&gt; containing alternating (variable name, value) pairs
        /// or a list of values in the exact order of declared input variables.
        /// </summary>
        public static void WriteInputValues(
            string formulaFilePath,
            List<object> inputValues)
        {
            if (inputValues == null || inputValues.Count == 0) return;

            var inputNames = GetInputVariables(formulaFilePath);
            var dict = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

            if (inputValues.Count == inputNames.Count)
            {
                // Truyền dạng: [val1, val2, val3]
                for (int i = 0; i < inputNames.Count; i++)
                {
                    string name = inputNames[i].ToString();
                    dict[name] = SafeToDouble(inputValues[i]);
                }
            }
            else
            {
                // Truyền dạng: [name1, val1, name2, val2]
                for (int i = 0; i < inputValues.Count - 1; i += 2)
                {
                    if (inputValues[i] == null) continue;
                    string name = inputValues[i].ToString().Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        dict[name] = SafeToDouble(inputValues[i + 1]);
                    }
                }
            }

            WriteInputValuesInternal(formulaFilePath, dict);
        }

        private static void WriteInputValuesInternal(
            string formulaFilePath,
            Dictionary<string, double> inputValues)
        {
            if (inputValues == null || inputValues.Count == 0) return;

            var lines = ReadLines(formulaFilePath).ToList();

            foreach (var kvp in inputValues)
            {
                string varName = kvp.Key.Trim();
                string newLine = $"{varName} = {kvp.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}";

                bool found = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    var trimmed = lines[i].Trim();
                    if (trimmed.StartsWith("INPUT:", StringComparison.OrdinalIgnoreCase) ||
                        trimmed.StartsWith("OUTPUT:", StringComparison.OrdinalIgnoreCase) ||
                        trimmed.StartsWith("#") || trimmed.StartsWith("//"))
                        continue;

                    int eq = trimmed.IndexOf('=');
                    if (eq > 0)
                    {
                        string lhsName = trimmed.Substring(0, eq).Trim();
                        if (lhsName.Equals(varName, StringComparison.OrdinalIgnoreCase))
                        {
                            lines[i] = newLine;
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    int insertIdx = -1;
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (lines[i].Trim().StartsWith("INPUT:", StringComparison.OrdinalIgnoreCase))
                        {
                            insertIdx = i + 1;
                            break;
                        }
                    }
                    if (insertIdx < 0) insertIdx = lines.Count;
                    lines.Insert(insertIdx, newLine);
                }
            }

            File.WriteAllLines(formulaFilePath, lines);
        }

        /// <summary>
        /// Calculates based on the formula file.
        /// Returns a List &lt;object&gt; containing the calculated values of OUTPUT variables in their declaration order.
        /// </summary>
        public static List<object> Calculate(string formulaFilePath) => Calculate(formulaFilePath, null);

        public static List<object> Calculate(Dictionary<string, double> inputValues) => Calculate(GetFormulaFilePath(), inputValues);

        public static List<object> Calculate(string formulaFilePath, Dictionary<string, double> inputValues)
        {
            var lines = new List<string>(ReadLines(formulaFilePath));

            if (inputValues != null && inputValues.Count > 0)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    var trimmed = lines[i].Trim();
                    if (trimmed.StartsWith("INPUT:", StringComparison.OrdinalIgnoreCase) ||
                        trimmed.StartsWith("OUTPUT:", StringComparison.OrdinalIgnoreCase) ||
                        trimmed.StartsWith("#") || trimmed.StartsWith("//"))
                        continue;

                    int eq = trimmed.IndexOf('=');
                    if (eq > 0)
                    {
                        string lhsName = trimmed.Substring(0, eq).Trim();
                        foreach (var kvp in inputValues)
                        {
                            if (lhsName.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase))
                            {
                                lines[i] = $"{kvp.Key} = {kvp.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                                break;
                            }
                        }
                    }
                }
            }

            var variables = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
            if (inputValues != null)
            {
                foreach (var kv in inputValues)
                {
                    variables[kv.Key] = kv.Value;
                }
            }
            var outputNames = new List<string>();

            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim();

                if (string.IsNullOrEmpty(line) ||
                    line.StartsWith("#") ||
                    line.StartsWith("//"))
                    continue;

                if (line.StartsWith("INPUT:", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (line.StartsWith("OUTPUT:", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = line.Substring(7)
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        var parsed = ParseVariableAndUnit(part);
                        if (!string.IsNullOrEmpty(parsed.name))
                            outputNames.Add(parsed.name);
                    }
                    continue;
                }

                int eqIdx = line.IndexOf('=');
                if (eqIdx > 0)
                {
                    string varName = line.Substring(0, eqIdx).Trim();
                    string exprText = line.Substring(eqIdx + 1).Trim();
                    double value = ParseAndEvaluate(exprText, variables);
                    variables[varName] = value;
                }
            }

            if (outputNames.Count == 0)
                throw new InvalidOperationException(
                    "No OUTPUT declaration found in the formula file.");

            var results = new List<object>();
            foreach (var outName in outputNames)
            {
                if (variables.TryGetValue(outName, out double val))
                    results.Add(val);
                else
                    throw new KeyNotFoundException(
                        $"Output variable '{outName}' has not been calculated in the formula file.");
            }
            return results;
        }

        /// <summary>Calculates and returns the first OUTPUT value (legacy API).</summary>
        public static double Evaluate(string formulaFilePath, Dictionary<string, double> inputs)
        {
            WriteInputValuesInternal(formulaFilePath, inputs);
            var results = Calculate(formulaFilePath);
            if (results.Count == 0)
                throw new InvalidOperationException("No output results.");
            return SafeToDouble(results[0]);
        }

        private static double SafeToDouble(object obj)
        {
            if (obj == null) return 0;
            if (obj is double d) return d;
            if (double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double res))
                return res;
            return 0;
        }        // ─────────────────────────────────────────────────────────────────────
        // Internal helpers
        // ─────────────────────────────────────────────────────────────────────

        private static string[] ReadLines(string formulaFilePath)
        {
            if (string.IsNullOrWhiteSpace(formulaFilePath))
                throw new ArgumentNullException(nameof(formulaFilePath),
                    "Formula file path cannot be empty.");

            if (!File.Exists(formulaFilePath))
                throw new FileNotFoundException(
                    $"Formula file not found: {formulaFilePath}");

            return File.ReadAllLines(formulaFilePath);
        }

        private static double ParseAndEvaluate(
            string expression,
            Dictionary<string, double> variables)
        {
            var parser = new ExpressionParser(expression, variables);
            return parser.Parse();
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Expression parser (unchanged)
    // ─────────────────────────────────────────────────────────────────────────

    internal class ExpressionParser
    {
        private readonly string _text;
        private readonly Dictionary<string, double> _variables;
        private int _pos;

        public ExpressionParser(string text, Dictionary<string, double> variables)
        {
            _text = text;
            _variables = variables;
            _pos = 0;
        }

        private char Peak()
        {
            if (_pos >= _text.Length) return '\0';
            return _text[_pos];
        }

        private char Next()
        {
            if (_pos >= _text.Length) return '\0';
            return _text[_pos++];
        }

        private void SkipWhitespace()
        {
            while (_pos < _text.Length && char.IsWhiteSpace(_text[_pos]))
                _pos++;
        }

        public double Parse()
        {
            double result = ParseExpression();
            SkipWhitespace();
            if (_pos < _text.Length)
                throw new Exception(
                    $"Invalid character '{_text[_pos]}' at position {_pos} in the expression: {_text}");
            return result;
        }

        private double ParseExpression() => ParseAdditive();

        private double ParseAdditive()
        {
            double left = ParseMultiplicative();
            while (true)
            {
                SkipWhitespace();
                char op = Peak();
                if (op == '+' || op == '-')
                {
                    Next();
                    double right = ParseMultiplicative();
                    left = op == '+' ? left + right : left - right;
                }
                else break;
            }
            return left;
        }

        private double ParseMultiplicative()
        {
            double left = ParsePower();
            while (true)
            {
                SkipWhitespace();
                char op = Peak();
                if (op == '*' || op == '/')
                {
                    Next();
                    double right = ParsePower();
                    if (op == '*') left *= right;
                    else
                    {
                        if (right == 0.0)
                            throw new DivideByZeroException("Division by zero in the expression.");
                        left /= right;
                    }
                }
                else break;
            }
            return left;
        }

        private double ParsePower()
        {
            double left = ParseUnary();
            while (true)
            {
                SkipWhitespace();
                if (Peak() == '^')
                {
                    Next();
                    double right = ParseUnary();
                    left = Math.Pow(left, right);
                }
                else break;
            }
            return left;
        }

        private double ParseUnary()
        {
            SkipWhitespace();
            char op = Peak();
            if (op == '-') { Next(); return -ParseUnary(); }
            if (op == '+') { Next(); return ParseUnary(); }
            return ParsePrimary();
        }

        private double ParsePrimary()
        {
            SkipWhitespace();
            char c = Peak();

            if (c == '(')
            {
                Next();
                double val = ParseExpression();
                SkipWhitespace();
                if (Peak() != ')')
                    throw new Exception("Missing closing parenthesis ')'");
                Next();
                return val;
            }

            if (char.IsDigit(c) || c == '.')
            {
                int start = _pos;
                while (_pos < _text.Length &&
                       (char.IsDigit(_text[_pos]) || _text[_pos] == '.'))
                    _pos++;
                string numStr = _text.Substring(start, _pos - start);
                if (double.TryParse(numStr,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double val))
                    return val;
                throw new Exception($"Invalid number: {numStr}");
            }

            if (char.IsLetter(c) || c == '_')
            {
                int start = _pos;
                while (_pos < _text.Length &&
                       (char.IsLetterOrDigit(_text[_pos]) || _text[_pos] == '_'))
                    _pos++;
                string name = _text.Substring(start, _pos - start);

                SkipWhitespace();
                if (Peak() == '(')
                {
                    Next();
                    double arg = ParseExpression();
                    SkipWhitespace();
                    if (Peak() != ')')
                        throw new Exception(
                            $"Missing closing parenthesis ')' for function {name}");
                    Next();

                    if (name.Equals("log10", StringComparison.OrdinalIgnoreCase))
                        return Math.Log10(arg);
                    if (name.Equals("log", StringComparison.OrdinalIgnoreCase))
                        return Math.Log(arg);
                    if (name.Equals("sqrt", StringComparison.OrdinalIgnoreCase))
                        return Math.Sqrt(arg);
                    if (name.Equals("abs", StringComparison.OrdinalIgnoreCase))
                        return Math.Abs(arg);

                    throw new NotSupportedException(
                        $"Function '{name}' is not supported.");
                }

                if (_variables.TryGetValue(name, out double varVal))
                    return varVal;

                throw new KeyNotFoundException(
                    $"Variable '{name}' has not been declared.");
            }

            throw new Exception(
                $"Invalid character '{c}' at position {_pos}");
        }
    }
}
