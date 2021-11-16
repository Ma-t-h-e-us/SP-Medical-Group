import React, { Component } from "react";
import { Link } from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from '../../services/auth';

//img:
import logo from '../../assets/img/logo.png'

class Header extends Component {

    logout = () => {
        localStorage.removeItem('usuario-login');
        console.log('Feito o logout');
    }

    render() {
        return (
            <section class="header">
                <div class="conteudoHeader container">
                <Link to="/Home"><img src={logo} alt="logo SpMedicalGroup"></img></Link>
                    <nav class="navHeader">
                        <Link to="/ListarConsultas"><a href="">Consultas</a></Link>
                        {
                           usuarioAutenticado() && parseJwt().role === '1' ? <Link to="/NovaConsulta"><a href="">Cadastrar Consulta</a></Link> : null
                        }
                        <Link to="/Login"><a href="" onClick={this.logout}>Sair</a></Link>
                    </nav>
                </div>
            </section>
        )
    }
}
export default Header