using System;

namespace lunaSOFT.Pojos.login
{
    class pojoLogin
    {
        private String pUsuario;
        private String pContraseña;
        private String pRol;

        public String usuario
        {
            get{ return pUsuario;}
            set { pUsuario = value; }
        }

        public String contraseña
        {
            get { return pContraseña; }
            set { pContraseña = value; }
        }

        public String rol
        {
            get { return pRol; }
            set { pRol = value; }
        }



    }
}
