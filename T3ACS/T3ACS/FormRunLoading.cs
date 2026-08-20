namespace T3ACS
{
    /// <summary>
    /// Form loading riêng cho luồng chạy procedure: hiển thị progress bar + status.
    /// Được mở/đóng tại FormMainRunStep.RunProcedureId, cập nhật tiến trình qua IProgress
    /// do FormRunMain.RunProcedureId báo về.
    /// </summary>
    public partial class FormRunLoading : Form
    {
        public FormRunLoading()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cập nhật phần trăm tiến trình (0..100). Thread-safe: luôn đẩy về UI thread.
        /// </summary>
        public void SetProgress(int percent)
        {
            if (percent < 0) percent = 0;
            if (percent > 100) percent = 100;

            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    // CustomProgressBar dùng giá trị 0..1
                    prgLoading.SetValue(percent / 100.0);
                    lblPercent.Text = percent + "%";
                }));
            }
        }

        /// <summary>
        /// Cập nhật dòng trạng thái mô tả bước đang xử lý. Thread-safe.
        /// </summary>
        public void SetStatus(string text)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = text ?? string.Empty;
                }));
            }
        }

        // Vẽ viền mảnh quanh form (borderless) để nhìn tách nền rõ ràng.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(210, 214, 226)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
