using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pirates.Rendering;
using Pirates.UnitTests;

namespace Pirates
{
    public partial class MainWindow : Form
    {

        private PictureBox SurfaceRenderer = new PictureBox();

        private GameEngineRenderer renderer;

        public MainWindow()
        {
            if (Utils.TESTS)
            {
                TestRunner.getInstance().runTests();
            }
            InitializeComponent();
            renderer = new GameEngineRenderer(this);

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Dock the PictureBox to the form and set its background to white.
            SurfaceRenderer.Dock = DockStyle.Fill;
            MapUtils.ARGBColor background = MapUtils.BackgroundARGBColor;
            SurfaceRenderer.BackColor = Color.FromArgb(background.Alpha, background.Red, background.Green, background.Blue);
            // Connect the Paint event of the PictureBox to the event handler method.
            SurfaceRenderer.Paint += new System.Windows.Forms.PaintEventHandler(this.surfaceRenderer_Paint);
            // Add the PictureBox control to the Form. 
            this.Controls.Add(SurfaceRenderer);
            renderer.startMainGameLoop();
        }
                       
        private void surfaceRenderer_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // Draw a string on the PictureBox.            
            renderer.invalidateMap(g);
            
        }

        public void invalidate()
        {
            SurfaceRenderer.Refresh();
        }

        private void frameRenderTimer_Tick(object sender, EventArgs e)
        {
            invalidate();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            renderer.stopMainGameLoop();
        }

    }
}
