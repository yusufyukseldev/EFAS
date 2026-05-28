using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace EFAS // Eğer senin projenin adı farklıysa buradaki namespace'i kendi projene göre değiştir
{
    public class RoundedPanel : Panel
    {
        // Yuvarlaklık derecesini buradan ayarlayabilirsin
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(20)]
        public int BorderRadius { get; set; } = 20;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Kenarları pürüzsüzleştirir (Pikselleşmeyi önler)

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90); // Sol üst
            path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90); // Sağ üst
            path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90); // Sağ alt
            path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90); // Sol alt
            path.CloseAllFigures();

            // Panelin şeklini bu çizdiğimiz yuvarlak yola göre kesiyoruz!
            this.Region = new Region(path);
        }
    }
}