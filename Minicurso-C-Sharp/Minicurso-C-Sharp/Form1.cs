using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minicurso_C_Sharp
{
    public partial class Form1 : Form
    {
        // lista de objetos na cena
        private readonly List<IDraw> _drawList;

        // objeto que está sendo criado atualmente
        private IDraw _currObject;

        public Form1()
        {
            InitializeComponent();

            _drawList = new List<IDraw>();
        }

        // método chamado toda vez que o painel é pintado
        private void OnCanvasPaint(object sender, PaintEventArgs e)
        {
            foreach (var draw in _drawList)
            {
                draw.Draw(e.Graphics);
            }

            // ?. é acesso condicional, ele vai chamar Draw se _currObject não for nulo
            _currObject?.Draw(e.Graphics);
        }

        // clique para criar linha
        private void CreateLineClick(object sender, EventArgs e)
        {
            ICreate ic = new LineCreator();

            // inicializa os listeners dos eventos
            ic.Finished += LineCreated;
            ic.Cancelled += LineCancelled;

            ic.RegisterEvents(canvas);

            // muda o objeto atual para a linha
            _currObject = ic.Result;
        }

        // usuário cancela a criação da linha
        private void LineCancelled(object sender, EventArgs e)
        {
            ClearLineCreator(sender as ICreate ?? throw new ArgumentException());
            canvas.Refresh();
        }

        // linha foi criada com sucesso
        private void LineCreated(object sender, EventArgs e)
        {
            // as é um cast, a diferença entre "sender as ICreate" e "(ICreate)sender"
            // é que o segundo lança exeption caso o sender não seja um ICreate
            // ?? atribuição condicional, ic recebe "sender as ICreate" se não for nulo,
            // se for lança uma exception
            var ic = sender as ICreate ?? throw new ArgumentException();
            _drawList.Add(ic.Result);
            ClearLineCreator(ic);
        }

        // limpa os eventos da linha
        private void ClearLineCreator(ICreate ic)
        {
            ic.ClearEvents();
            ic.Finished -= LineCreated;
            ic.Cancelled -= LineCancelled;
            _currObject = null;
        }
    }
}
