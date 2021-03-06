﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using Pirates.Rendering;
using Pirates.UnitTests;
using Pirates.GameObjects.Players;

namespace Pirates.Windows
{
    public partial class MainWindow : Form
    {
        public interface PlayerInputListener
        {
            bool onClickAction(MouseEventArgs e);

            bool onMouseMove(MouseEventArgs e);
        }

        private PictureBox SurfaceRenderer = new PictureBox();

        private GameEngineRenderer renderer;

        private MenuHandler menu;

        private List<PlayerInputListener> listeners;

        internal GameEngineRenderer.GameEngineRendererMode nextMode { set; get; }

        public MainWindow()
        {
            if (Utils.TESTS)
            {
                TestRunner.getInstance().runTests();
            }
            InitializeComponent();
            listeners = new List<PlayerInputListener>();
            SurfaceRenderer.Dock = DockStyle.Fill;
            nextMode = GameEngineRenderer.GameEngineRendererMode.NONE;
            ViewPortHelper.getInstance(0, 0, 1024, 768);
            renderer = new GameEngineRenderer(this);

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Dock the PictureBox to the form and set its background to white.            
            
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
            if (Owner != null)
            {
                Owner.Show();
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                renderer.playerInfo.updateAngle(PlayerInfoAngle.RIGHT);
            }
            if (e.KeyCode == Keys.Left)
            {
                renderer.playerInfo.updateAngle(PlayerInfoAngle.LEFT);
            }            
        }

        public void registerListener(PlayerInputListener listener)
        {
            listeners.Add(listener);
        }

        public void unregisterListener(PlayerInputListener listener)
        {
            listeners.Remove(listener);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            //MessageBox.Show("resizeBegin");
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            //MessageBox.Show("resizeEnd");
        }

        protected override void OnResize(EventArgs e)
        {
            //MessageBox.Show("resize");
            //do nothing
        }

        internal void pause()
        {
            frameRenderTimer.Stop();
        }

        internal void resume()
        {
            frameRenderTimer.Start();
        }

        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (PlayerInputListener listener in listeners)
            {
                if (listener.onClickAction(e))
                {
                    break;
                }
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (PlayerInputListener listener in listeners)
            {
                if (listener.onMouseMove(e))
                {
                    break;
                }
            }
        }
    }
}
