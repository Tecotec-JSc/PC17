using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Controls.Buttons;
using T3ACS.Model.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace T3ACS
{
    public class BaseForm : Form
    {
        public BaseForm()
        {          
         
        }    
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyStyle(this);
            ConfigureMenuSw(this);
        }

        private static readonly HashSet<Control> ControlsBeingStyled = new HashSet<Control>();
        private void ApplyStyle(Control parent)
        {
            if (parent == null) return;
            if (ControlsBeingStyled.Contains(parent)) return;
            ControlsBeingStyled.Add(parent);
            try
            {
                if (parent is IThemeSupport themeControl)
                {
                    themeControl.ApplyTheme();
                    if (themeControl is Panel panel)
                    {
                        if (panel.Controls.Count > 0)
                        {
                            foreach (Control c in panel.Controls) ApplyStyle(c);
                        }
                    }
                }
                else
                {
                    if (parent is Form form)
                    {
                        form.ForeColor =ThemeManager.GetColorBy(form.ForeColor, 1);
                        form.BackColor = ThemeManager.GetColorBy(form.BackColor, 0);
                        form.Font = ThemeManager.ThemeSelect.FontDefault;
                        if (form.Controls.Count > 0)
                        {
                            foreach (Control c in form.Controls) ApplyStyle(c);
                        }
                    }
                    else if (parent is Panel panel)
                    {
                        panel.ForeColor= ThemeManager.GetColorBy(panel.ForeColor, 1);
                        if (panel.Controls.Count > 0)
                        {
                            foreach (Control c in panel.Controls) ApplyStyle(c);
                        }
                    }
                    else if (parent is Label lbl)
                    {
                        lbl.ForeColor = ThemeManager.GetColorBy(lbl.ForeColor, 1);
                        if (lbl.Parent is PanelBorderRadiusCustom p)
                        {
                            lbl.BackColor = p.BackColorG;
                        }
                        else lbl.BackColor = lbl.Parent.BackColor;
                    }
                    else if(parent is Button btn)
                    {                       
                        var imag = ThemeManager.GetImageBy(btn.Name);
                        if (imag != null) btn.Image = imag;
                        if (btn.Enabled)
                        {
                            btn.FlatAppearance.MouseOverBackColor = ThemeManager.GetColorBy(btn.FlatAppearance.MouseOverBackColor, 2);
                            btn.FlatAppearance.MouseDownBackColor = ThemeManager.GetColorBy(btn.FlatAppearance.MouseDownBackColor, 2);
                        }
                        btn.BackColor= ThemeManager.GetColorBy(btn.BackColor, 0);
                    }                   
                }               
            }
            finally
            {
                ControlsBeingStyled.Remove(parent);
            }
        }

        private void SetStyle(Control c, ThemeViewModel defaultTheme, ThemeViewModel selectTheme)
        {

        }

        private void ConfigureMenuSw(Control parent)
        {
            if (parent == null) return;

            if (parent.Name == "menuSw" && parent is MenuStrip menuStrip)
            {
                var theme = ThemeT3ACS.IsSelectedTheme ? ThemeManager.ThemeSelect : ThemeManager.DefaultTheme;
                if (theme != null)
                {
                    var renderer = new MenuSwRenderer(theme);
                    menuStrip.Renderer = renderer;
                    AssignRendererToDropdowns(menuStrip, renderer);
                }
                ApplyHandCursorToToolStrip(menuStrip);
                return;
            }

            foreach (Control c in parent.Controls)
            {
                ConfigureMenuSw(c);
            }
        }

        /// <summary>
        /// dropdown MenuStrip
        /// </summary>
        private static void AssignRendererToDropdowns(ToolStrip toolStrip, ToolStripRenderer renderer)
        {
            if (toolStrip == null || renderer == null) return;
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.DropDown.Renderer = renderer;
                    AssignRendererToDropdowns(menuItem.DropDown, renderer);
                }
            }
        }

        private static void ApplyHandCursorToToolStrip(ToolStrip toolStrip)
        {
            toolStrip.Cursor = Cursors.Hand;
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    ApplyHandCursorToToolStrip(menuItem.DropDown);
                }
            }
            toolStrip.ItemAdded += (s, ev) =>
            {
                if (ev.Item is ToolStripMenuItem menuItem)
                {
                    ApplyHandCursorToToolStrip(menuItem.DropDown);
                }
            };
        }

        /// <summary>
        // Bảng màu
        /// </summary>
        private class MenuSwColorTable : ProfessionalColorTable
        {
            private readonly ThemeViewModel _theme;

            public MenuSwColorTable(ThemeViewModel theme)
            {
                _theme = theme;
            }
            public override Color MenuBorder => _theme.BorderColors[0];
            public override Color ToolStripBorder => _theme.BorderColors[0];
            public override Color MenuItemBorder => _theme.HighlighBorderColor;
            public override Color MenuItemSelected => _theme.HighlighBackColor;
            public override Color MenuItemSelectedGradientBegin => _theme.HighlighBackColor;
            public override Color MenuItemSelectedGradientEnd => _theme.HighlighBackColor;
            public override Color MenuItemPressedGradientBegin => _theme.HighlighBackColor;
            public override Color MenuItemPressedGradientMiddle => _theme.HighlighBackColor;
            public override Color MenuItemPressedGradientEnd => _theme.HighlighBackColor;
            public override Color ToolStripDropDownBackground => _theme.BackColors[0];
            public override Color ImageMarginGradientBegin => _theme.BackColors[0];
            public override Color ImageMarginGradientMiddle => _theme.BackColors[0];
            public override Color ImageMarginGradientEnd => _theme.BackColors[0];
        }

        /// <summary>
        /// MenuStrip (menuSw)
        /// hover
        /// </summary>
        private class MenuSwRenderer : ToolStripProfessionalRenderer
        {
            private readonly ThemeViewModel _theme;

            public MenuSwRenderer(ThemeViewModel theme) : base(new MenuSwColorTable(theme))
            {
                _theme = theme;
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                // Khi mục menu được trỏ chuột qua (hover) hoặc được nhấn
                if (e.Item.Selected || e.Item.Pressed)
                {
                    var rect = new Rectangle(Point.Empty, e.Item.Size);

                    // Vẽ nền hover
                    using (var brush = new SolidBrush(_theme.HighlighBackColor))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }

                    // Vẽ viền hover 
                    if (_theme.HighlighBorderColor != Color.Empty && _theme.HighlighBorderColor != Color.Transparent)
                    {
                        using (var pen = new Pen(_theme.HighlighBorderColor, 1))
                        {
                            e.Graphics.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
                        }
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // dropdown menu
                if (e.ToolStrip is ToolStripDropDown)
                {
                    // Vẽ viền của ô menu sổ xuống 
                    using (var pen = new Pen(_theme.BorderColors[0], 1))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                    }
                }
                else
                {
                    base.OnRenderToolStripBorder(e);
                }
            }
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = _theme.ForeColors[0];
                base.OnRenderItemText(e);
            }

          
        }

        private void EnsureThemedIconsExist(string pathIcon)
        {
            try
            {
                if (!System.IO.Directory.Exists(pathIcon))
                {
                    System.IO.Directory.CreateDirectory(pathIcon);
                }

                string projectIconDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Properties\Icon");
                if (System.IO.Directory.Exists(projectIconDir))
                {
                    string editSrc = System.IO.Path.Combine(projectIconDir, "iconEditWhite.png");
                    string editDest = System.IO.Path.Combine(pathIcon, "IconEdit.png");
                    if (System.IO.File.Exists(editSrc) && !System.IO.File.Exists(editDest))
                    {
                        System.IO.File.Copy(editSrc, editDest);
                    }
                    string saveSrc = System.IO.Path.Combine(projectIconDir, "IconSaveWhite.png");
                    string saveDest = System.IO.Path.Combine(pathIcon, "IconSave.png");
                    if (System.IO.File.Exists(saveSrc) && !System.IO.File.Exists(saveDest))
                    {
                        System.IO.File.Copy(saveSrc, saveDest);
                    }

                    string deleteSrc = System.IO.Path.Combine(projectIconDir, "iconDelete.png");
                    string deleteDest = System.IO.Path.Combine(pathIcon, "IconDelete.png");
                    if (System.IO.File.Exists(deleteSrc) && !System.IO.File.Exists(deleteDest))
                    {
                        System.IO.File.Copy(deleteSrc, deleteDest);
                    }
                }
            }
            catch { }
        }

    }
}
