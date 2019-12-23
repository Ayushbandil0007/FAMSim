using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public enum SurfaceType
    {
        planer,
        slopeInsert,
        slopeCutting,
        edgeThrough,
        step,
        corner,
        customSurface
    }
    public partial class SelectWorkpieceProfileForm : Form
    {
        private ToolParametersForm prevForm;

        public SelectWorkpieceProfileForm(ToolParametersForm prevForm)
        {
            this.prevForm = prevForm;
            Top = prevForm.Top;
            Left = prevForm.Left;
            InitializeComponent();
        }

        private void selectSurfaceBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.prevForm.Show();
        }

        private void SelectSurfaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void surface1Button_Click(object sender, EventArgs e)
        {
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(this,null,SurfaceType.planer);
            toolInitialPositionForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GenerateCustomSurface generateCustomSurface = new GenerateCustomSurface(this);
            generateCustomSurface.Show();
        }

        private void surfaceEdgeInsert_Click(object sender, EventArgs e)
        {
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(this, null, SurfaceType.slopeInsert);
            toolInitialPositionForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(this, null, SurfaceType.slopeCutting);
            toolInitialPositionForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(this, null, SurfaceType.edgeThrough);
            toolInitialPositionForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(this, null, SurfaceType.step);
            toolInitialPositionForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToolInitialPositionForm toolInitialPositionForm = new ToolInitialPositionForm(this, null, SurfaceType.corner);
            toolInitialPositionForm.Show();
            this.Hide();
        }
    }
}
