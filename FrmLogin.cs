using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindAppplogin
{
    public partial class FrmLogin : Form
    {
        private string userCorrecto = "admin";
        private string claveCorrecta = "1234";

        public FrmLogin()
        {
            InitializeComponent();

            // Evita parpadeo del degradado
            this.DoubleBuffered = true;

            // Evento del botón
            btnIngresar.Click += BtnIngresar_Click;

            // ENTER en TextBox con KeyPress
            txtUsuario.KeyPress += TxtBoxes_KeyPress;
            txtClave.KeyPress += TxtBoxes_KeyPress;

            // ENTER en cualquier parte del formulario
            this.KeyPreview = true;
            this.KeyPress += FrmLogin_KeyPress;
        }

        // ====================================
        //   ENTER en TextBox con KeyPress
        // ====================================
        private void TxtBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BtnIngresar_Click(sender, e);
            }
        }

        // ====================================
        //   ENTER en el formulario
        // ====================================
        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BtnIngresar_Click(sender, e);
            }
        }

        // ====================================
        //   FONDO DEGRADADO
        // ====================================
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.DeepSkyBlue,   // Color inicial
                Color.White,         // Color final
                90f                  // Dirección vertical
            );

            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // ====================================
        //   LÓGICA DEL LOGIN
        // ====================================
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            // Restaurar color
            txtUsuario.BackColor = Color.White;
            txtClave.BackColor = Color.White;

            // Usuario vacío
            if (usuario == "")
            {
                MessageBox.Show("⚠️ Ingrese el usuario.",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.BackColor = Color.MistyRose;
                txtUsuario.Focus();
                return;
            }

            // Contraseña vacía
            if (clave == "")
            {
                MessageBox.Show("⚠️ Ingrese la contraseña.",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.BackColor = Color.MistyRose;
                txtClave.Focus();
                return;
            }

            // Usuario incorrecto
            if (usuario != userCorrecto)
            {
                MessageBox.Show("❌ El usuario es incorrecto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.BackColor = Color.MistyRose;
                txtUsuario.Focus();
                return;
            }

            // Contraseña incorrecta
            if (clave != claveCorrecta)
            {
                MessageBox.Show("❌ La contraseña es incorrecta.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.BackColor = Color.MistyRose;
                txtClave.Focus();
                return;
            }

            // Acceso correcto
            MessageBox.Show("✅ Bienvenido al sistema",
                "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ============================================================
            //  AQUÍ VA EL CÓDIGO PARA ABRIR OTRA VENTANA (LO DEJÉ COMENTADO)
            // ============================================================
            /*
            FormMenu ventana = new FormMenu();
            ventana.Show();
            this.Hide();
            */
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
